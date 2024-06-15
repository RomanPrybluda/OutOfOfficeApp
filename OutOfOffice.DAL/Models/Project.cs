namespace OutOfOffice.DAL
{
    public class Project
    {
        public Guid Id { get; set; }

        public Guid ProjectTypeId { get; set; }

        public ProjectType? ProjectType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid ProjectManagerId { get; set; }

        public Employee? ProjectManager { get; set; }

        public string? Comment { get; set; }

        public Guid ProjectStatusId { get; set; }

        public ProjectStatus? ProjectStatus { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
