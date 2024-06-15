namespace OutOfOffice.DAL
{
    public class EmployeeStatus
    {
        public Guid Id { get; set; }

        public string? EmployeeStatusName { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}