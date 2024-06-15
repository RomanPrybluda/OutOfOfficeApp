namespace OutOfOffice.DAL
{
    public class Position
    {
        public Guid Id { get; set; }

        public string? PositionName { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}