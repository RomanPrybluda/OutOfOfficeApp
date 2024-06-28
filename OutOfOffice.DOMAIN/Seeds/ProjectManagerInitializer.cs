using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class ProjectManagerInitializer
    {
        private readonly AppDbContext _context;
        private readonly Random _random;

        public ProjectManagerInitializer(AppDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public void InitializeProjectManagers()
        {
            var projectManagerPositionName = Enum.GetName(typeof(Positions), Positions.ProjectManager);

            var existingProjectManagersCount = _context.Employees.Count(e => e.Position.PositionName == projectManagerPositionName);
            if (existingProjectManagersCount >= SeedConstants.NUMBER_OF_PROJECT_MANAGERS)
            {
                return;
            }

            var projectManagerRoleName = Enum.GetName(typeof(RoleNames), RoleNames.ProjectManager);
            var projectManagerAppUsers = _context.AppUsers.Where(u => u.Role.RoleName == projectManagerRoleName).ToList();

            if (projectManagerAppUsers.Count == 0)
            {
                throw new InvalidOperationException("No AppUsers with Role == ProjectManager found.");
            }

            var subdivisions = _context.Subdivisions.ToList();
            var positions = _context.Positions.ToList();
            var employeeStatuses = _context.EmployeeStatuses.ToList();

            var firstProjectManagerAppUser = projectManagerAppUsers[0];
            projectManagerAppUsers.RemoveAt(0);

            var firstProjectManager = new Employee
            {
                Id = Guid.NewGuid(),
                FullName = firstProjectManagerAppUser.FullName ?? "Initial Project Manager",
                OutOfOfficeBalance = _random.Next(SeedConstants.MIN_OUT_OF_OFFICE_BALANCE, SeedConstants.MAX_OUT_OF_OFFICE_BALANCE),
                SubdivisionId = subdivisions.Any() ? subdivisions[_random.Next(subdivisions.Count)].Id : Guid.Empty,
                PositionId = positions.Any(p => p.PositionName == projectManagerPositionName) ? positions.First(p => p.PositionName == projectManagerPositionName).Id : Guid.Empty,
                EmployeeStatusId = employeeStatuses.Any() ? employeeStatuses[_random.Next(employeeStatuses.Count)].Id : Guid.Empty,
                PeoplePartnerId = null,
                Photo = new byte[0],
                AppUserId = firstProjectManagerAppUser.Id,
                AppUser = firstProjectManagerAppUser
            };

            _context.Employees.Add(firstProjectManager);
            _context.SaveChanges();

            var firstProjectManagerId = firstProjectManager.Id;

            foreach (var projectManagerAppUser in projectManagerAppUsers)
            {
                var newProjectManager = new Employee
                {
                    Id = Guid.NewGuid(),
                    FullName = projectManagerAppUser.FullName ?? $"Project Manager {projectManagerAppUser.Id}",
                    OutOfOfficeBalance = _random.Next(SeedConstants.MIN_OUT_OF_OFFICE_BALANCE, SeedConstants.MAX_OUT_OF_OFFICE_BALANCE),
                    SubdivisionId = subdivisions.Any() ? subdivisions[_random.Next(subdivisions.Count)].Id : Guid.Empty,
                    PositionId = positions.Any(p => p.PositionName == projectManagerPositionName) ? positions.First(p => p.PositionName == projectManagerPositionName).Id : Guid.Empty,
                    EmployeeStatusId = employeeStatuses.Any() ? employeeStatuses[_random.Next(employeeStatuses.Count)].Id : Guid.Empty,
                    PeoplePartnerId = firstProjectManagerId,
                    Photo = new byte[0],
                    AppUserId = projectManagerAppUser.Id,
                    AppUser = projectManagerAppUser
                };

                _context.Employees.Add(newProjectManager);
            }

            _context.SaveChanges();

            var remainingProjectManagers = _context.Employees.Where(e => e.Position.PositionName == projectManagerPositionName && e.Id != firstProjectManagerId).ToList();
            if (remainingProjectManagers.Any())
            {
                var randomProjectManager = remainingProjectManagers[_random.Next(remainingProjectManagers.Count)];
                firstProjectManager.PeoplePartnerId = randomProjectManager.Id;
                _context.Employees.Update(firstProjectManager);
                _context.SaveChanges();
            }
        }
    }
}
