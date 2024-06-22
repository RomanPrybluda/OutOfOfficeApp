namespace OutOfOffice.DAL
{
    public class EmployeeStatus
    {
        public Guid Id { get; set; }

        public string EmployeeStatusName { get; set; } = string.Empty;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}