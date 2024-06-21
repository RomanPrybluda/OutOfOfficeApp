namespace OutOfOffice.DAL
{
    public class Subdivision
    {
        public Guid Id { get; set; }

        public string SubdivisionName { get; set; } = string.Empty;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}