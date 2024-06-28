using OutOfOffice.DAL;
using System.Data;

namespace OutOfOffice.DOMAIN
{
    public class EmployeeInitializer
    {
        private readonly AppDbContext _context;
        private readonly Random _random;

        public EmployeeInitializer(AppDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public void InitializeEmployees()
        {
            // Step 1: Check if there are already 75 Employees with Position other than HRManager and ProjectManager
            var nonManagerPositions = new List<string>
            {
                Enum.GetName(typeof(Positions), Positions.Developer),
                Enum.GetName(typeof(Positions), Positions.TeamLead),
                Enum.GetName(typeof(Positions), Positions.QAEngineer),
                Enum.GetName(typeof(Positions), Positions.DevOps),
                Enum.GetName(typeof(Positions), Positions.SystemAdministrator),
                Enum.GetName(typeof(Positions), Positions.BusinessAnalyst),
                Enum.GetName(typeof(Positions), Positions.ProductOwner),
                Enum.GetName(typeof(Positions), Positions.ScrumMaster)
            };

            var existingNonManagerEmployeesCount = _context.Employees.Count(e => nonManagerPositions.Contains(e.Position.PositionName));

            if (existingNonManagerEmployeesCount >= SeedConstants.NUMBER_OF_EMPLOYEE)
            {
                return;
            }

            // Step 2: Select all AppUsers with Role not equal to HRManager and ProjectManager
            var hrManagerRoleName = Enum.GetName(typeof(RoleNames), RoleNames.HRManager);
            var projectManagerRoleName = Enum.GetName(typeof(RoleNames), RoleNames.ProjectManager);
            var nonManagerAppUsers = _context.AppUsers.Where(u => u.Role.RoleName != hrManagerRoleName && u.Role.RoleName != projectManagerRoleName).ToList();

            // Step 3: Select all Employees with Position == HRManager
            var hrManagerPositionName = Enum.GetName(typeof(Positions), Positions.HRManager);
            var hrManagers = _context.Employees.Where(e => e.Position.PositionName == hrManagerPositionName).ToList();

            if (!hrManagers.Any())
            {
                throw new InvalidOperationException("No Employees with Position == HRManager found.");
            }

            // Step 4: Create new Employees with random non-manager positions and link them to non-manager AppUsers
            var subdivisions = _context.Subdivisions.ToList();
            var positions = _context.Positions.Where(p => nonManagerPositions.Contains(p.PositionName)).ToList();
            var employeeStatuses = _context.EmployeeStatuses.ToList();

            foreach (var appUser in nonManagerAppUsers.Take(75 - existingNonManagerEmployeesCount))
            {
                var subdivision = subdivisions[_random.Next(subdivisions.Count)].Id;
                var position = positions[_random.Next(positions.Count)].Id;
                var employeeStatus = employeeStatuses[_random.Next(employeeStatuses.Count)].Id;
                var randomHrManagerId = hrManagers[_random.Next(hrManagers.Count)].Id;

                var newEmployee = new Employee
                {
                    Id = Guid.NewGuid(),
                    FullName = appUser.FullName ?? "Unknown",
                    AppUserId = appUser.Id,
                    AppUser = appUser,
                    OutOfOfficeBalance = _random.Next(
                        SeedConstants.MIN_OUT_OF_OFFICE_BALANCE,
                        SeedConstants.MAX_OUT_OF_OFFICE_BALANCE),
                    SubdivisionId = subdivision,
                    PositionId = position,
                    EmployeeStatusId = employeeStatus,
                    PeoplePartnerId = randomHrManagerId,
                    Photo = new byte[0]
                };

                _context.Employees.Add(newEmployee);
            }

            _context.SaveChanges();
        }
    }
}