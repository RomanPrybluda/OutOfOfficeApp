﻿using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class EmployeeInitializer
    {
        private readonly AppDbContext _context;

        public EmployeeInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeEmployees()
        {
            var existingEmployeeNames = _context.Employees.Select(e => e.FullName).ToList();

            var appUsersWithoutEmployees = _context.AppUsers
                .Where(u => u.CurrentEmployee == null)
                .Take(100 - _context.Employees.Count())
                .ToList();

            var defaultSubdivisionId = _context.Subdivisions.FirstOrDefault()?.Id ?? Guid.NewGuid();
            var defaultPositionId = _context.Positions.FirstOrDefault()?.Id ?? Guid.NewGuid();
            var defaultEmployeeStatusId = _context.EmployeeStatuses.FirstOrDefault()?.Id ?? Guid.NewGuid();
            var defaultPeoplePartnerId = _context.Employees.FirstOrDefault()?.Id ?? Guid.NewGuid();

            foreach (var appUser in appUsersWithoutEmployees)
            {
                if (!existingEmployeeNames.Contains(appUser.FullName))
                {
                    var employee = new Employee(appUser, appUser.FullName)
                    {
                        Id = Guid.NewGuid(),
                        SubdivisionId = defaultSubdivisionId,
                        PositionId = defaultPositionId,
                        EmployeeStatusId = defaultEmployeeStatusId,
                        PeoplePartnerId = defaultPeoplePartnerId,
                        OutOfOfficeBalance = 0,
                        Photo = null
                    };

                    _context.Employees.Add(employee);
                    existingEmployeeNames.Add(appUser.FullName);
                }
            }

            _context.SaveChanges();
        }
    }
}