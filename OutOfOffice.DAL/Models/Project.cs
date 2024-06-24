namespace OutOfOffice.DAL
{
    public class Project
    {
        public Guid Id { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public Guid ProjectTypeId { get; set; }

        public ProjectType ProjectType { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid ProjectManagerId { get; set; }

        public Employee ProjectManager { get; set; } = null!;

        public string Comment { get; set; } = string.Empty;

        public Guid ProjectStatusId { get; set; }

        public ProjectStatus ProjectStatus { get; set; } = null!;

        public ICollection<ProjectEmployee> Employees { get; set; } = new List<ProjectEmployee>();

    }
}