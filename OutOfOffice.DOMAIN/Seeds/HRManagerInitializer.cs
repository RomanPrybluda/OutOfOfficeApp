using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class HRManagerInitializer
    {
        private readonly AppDbContext _context;
        private readonly Random _random;

        public HRManagerInitializer(AppDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public void InitializeHRManagers()
        {
            var hrManagerPositionName = Enum.GetName(typeof(Positions), Positions.HRManager);

            // Step 1: Check if there are already 10 HRManagers in the database
            var existingHRManagersCount = _context.Employees.Count(e => e.Position.PositionName == hrManagerPositionName);
            if (existingHRManagersCount >= SeedConstants.NUMBER_OF_HR_MANAGERS)
            {
                return;
            }

            // Step 2: Select all AppUsers with Role == HRManager
            var hrManagerRoleName = Enum.GetName(typeof(RoleNames), RoleNames.HRManager);
            var hrManagerAppUsers = _context.AppUsers.Where(u => u.Role.RoleName == hrManagerRoleName).ToList();

            if (hrManagerAppUsers.Count == 0)
            {
                throw new InvalidOperationException("No AppUsers with Role == HRManager found.");
            }

            // Step 3: Create the first Employee and link it with one of the HRManager AppUsers
            var subdivisions = _context.Subdivisions.ToList();
            var positions = _context.Positions.ToList();
            var employeeStatuses = _context.EmployeeStatuses.ToList();

            var firstHrManagerAppUser = hrManagerAppUsers[0];
            hrManagerAppUsers.RemoveAt(0);

            var firstHrManager = new Employee
            {
                Id = Guid.NewGuid(),
                FullName = firstHrManagerAppUser.FullName ?? "Initial HR Manager",
                OutOfOfficeBalance = _random.Next(
                    SeedConstants.MIN_OUT_OF_OFFICE_BALANCE,
                    SeedConstants.MAX_OUT_OF_OFFICE_BALANCE),
                SubdivisionId = subdivisions.Any() ? subdivisions[_random.Next(subdivisions.Count)].Id : Guid.Empty,
                PositionId = positions.Any(p => p.PositionName == hrManagerPositionName) ? positions.First(p => p.PositionName == hrManagerPositionName).Id : Guid.Empty,
                EmployeeStatusId = employeeStatuses.Any() ? employeeStatuses[_random.Next(employeeStatuses.Count)].Id : Guid.Empty,
                PeoplePartnerId = null,
                Photo = new byte[0],
                AppUserId = firstHrManagerAppUser.Id,
                AppUser = firstHrManagerAppUser
            };

            _context.Employees.Add(firstHrManager);
            _context.SaveChanges();

            // Step 4: Get the ID of the just created Employee
            var firstHrManagerId = firstHrManager.Id;

            // Step 5: Create the remaining HRManagers
            foreach (var hrManagerAppUser in hrManagerAppUsers)
            {
                var newHrManager = new Employee
                {
                    Id = Guid.NewGuid(),
                    FullName = hrManagerAppUser.FullName ?? $"HR Manager {hrManagerAppUser.Id}",
                    OutOfOfficeBalance = _random.Next(
                        SeedConstants.MIN_OUT_OF_OFFICE_BALANCE,
                        SeedConstants.MAX_OUT_OF_OFFICE_BALANCE),
                    SubdivisionId = subdivisions.Any() ? subdivisions[_random.Next(subdivisions.Count)].Id : Guid.Empty,
                    PositionId = positions.Any(p => p.PositionName == hrManagerPositionName) ? positions.First(p => p.PositionName == hrManagerPositionName).Id : Guid.Empty,
                    EmployeeStatusId = employeeStatuses.Any() ? employeeStatuses[_random.Next(employeeStatuses.Count)].Id : Guid.Empty,
                    PeoplePartnerId = firstHrManagerId,
                    Photo = new byte[0],
                    AppUserId = hrManagerAppUser.Id,
                    AppUser = hrManagerAppUser
                };

                _context.Employees.Add(newHrManager);
            }

            _context.SaveChanges();

            // Step 6: Update the first HRManager's PeoplePartnerId to the ID of any other HRManager
            var remainingHrManagers = _context.Employees.Where(e => e.Position.PositionName == hrManagerPositionName && e.Id != firstHrManagerId).ToList();
            if (remainingHrManagers.Any())
            {
                var randomHrManager = remainingHrManagers[_random.Next(remainingHrManagers.Count)];
                firstHrManager.PeoplePartnerId = randomHrManager.Id;
                _context.Employees.Update(firstHrManager);
                _context.SaveChanges();
            }
        }
    }
}