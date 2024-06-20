namespace OutOfOffice.DAL
{
    public class Role
    {
        public Guid Id { get; set; }

        public string? RoleName { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}