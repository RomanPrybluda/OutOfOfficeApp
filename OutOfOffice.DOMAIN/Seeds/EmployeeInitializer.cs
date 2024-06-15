using System;
using System.Collections.Generic;
using System.Linq;
using OutOfOffice.DAL;

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
            var employeeNames = new List<string>
            {
                "John Doe", "Jane Smith", "Michael Johnson", "Emily Brown",
                "Daniel Williams", "Olivia Jones", "David Garcia", "Sophia Davis",
                "James Miller", "Isabella Martinez", "Benjamin Lopez", "Emma Wilson",
                "William Moore", "Mia Taylor", "Alexander Anderson", "Ava Thomas",
                "Elijah Harris", "Charlotte Clark", "Gabriel Lewis", "Grace Walker",
                "Samuel Young", "Lily Rodriguez", "Nathan White", "Ella Hall",
                "Christopher King", "Madison Scott", "Joshua Green", "Amelia Adams",
                "Andrew Baker", "Abigail Campbell", "Joseph Martinez", "Samantha Nelson",
                "Logan Mitchell", "Hannah Carter", "Matthew Perez", "Avery Roberts",
                "Ryan Turner", "Victoria Hill", "Dylan Phillips", "Chloe Evans",
                "Luke Foster", "Zoe Murphy", "Carter Howard", "Evelyn Sanchez",
                "Isaac Torres", "Grace Rivera", "Jackson Cooper", "Audrey Brooks",
                "Jack Reed", "Penelope Perry", "Owen Ward", "Nora Bell",
                "Caleb Coleman", "Hazel Bailey", "Wyatt Barnes", "Ellie Price",
                "Julian Peterson", "Sofia Long", "Grayson Jenkins", "Scarlett Foster",
                "Liam Stewart", "Ruby Watson", "Connor Hughes", "Mila Sanders",
                "Jayden Gray", "Luna Gonzales", "Christian Ramirez", "Lillian Russell",
                "Isaiah Diaz", "Willow Hughes", "Charles Kelly", "Eleanor Powell",
                "Hunter Roberts", "Aria Murphy", "Thomas Gonzales", "Nova Richardson",
                "Aaron Nelson", "Emilia Young", "Adrian Cook", "Aurora Parker",
                "Evan Coleman", "Leah Brooks", "Jason Flores", "Haley Peterson",
                "Nolan Torres", "Anna Bennett", "Colton Washington", "Elizabeth Foster",
                "Gavin Jenkins", "Layla Butler", "Nicholas Price", "Aria Hughes",
                "Jordan Ward", "Addison Carter", "Tyler Ramirez", "Brooklyn Morris"
            };


            var existingEmployeeNames = _context.Employees.Select(e => e.FullName).ToList();

            foreach (var employeeName in employeeNames)
            {
                if (!existingEmployeeNames.Contains(employeeName))
                {
                    _context.Employees.Add(new Employee
                    {
                        Id = Guid.NewGuid(),
                        FullName = employeeName,
                        SubdivisionId = Guid.NewGuid(),
                        PositionId = Guid.NewGuid(),    
                        EmployeeStatusId = Guid.NewGuid(), 
                        PeoplePartnerId = Guid.NewGuid(), 
                        OutOfOfficeBalance = 0,          
                        Photo = null                      
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}
