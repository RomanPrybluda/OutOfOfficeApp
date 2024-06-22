using OutOfOffice.DAL; 


namespace OutOfOffice.DOMAIN
{
    public class EmployeeStatusInitializer
    {
        private readonly AppDbContext _context;

        public EmployeeStatusInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeEmployeeStatuses()
        {
            var employeeStatusNames = Enum.GetNames(typeof(EmployeeStatuses));

            var existingEmployeeStatuses = _context.EmployeeStatuses.Select(es => es.EmployeeStatusName).ToList();

            foreach (var employeeStatusName in employeeStatusNames)
            {
                if (!existingEmployeeStatuses.Contains(employeeStatusName))
                {
                    _context.EmployeeStatuses.Add(new EmployeeStatus
                    {
                        Id = Guid.NewGuid(),
                        EmployeeStatusName = employeeStatusName
                    });
                }
            }

            _context.SaveChanges();
        }
    }

}
