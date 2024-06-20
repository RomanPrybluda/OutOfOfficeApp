using OutOfOffice.DAL.Models;

namespace OutOfOffice.DAL
{
    public class Project
    {
        public Guid Id { get; set; }

        public string? ProjectName { get; set; }

        public Guid ProjectTypeId { get; set; }

        public ProjectType? ProjectType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid ProjectManagerId { get; set; }

        public Employee ProjectManager { get; set; } = null!;

        public string? Comment { get; set; }

        public Guid ProjectStatusId { get; set; }

        public ProjectStatus? ProjectStatus { get; set; }

        public ICollection<ProjectEmployee> Employees { get; set; }

    }
}