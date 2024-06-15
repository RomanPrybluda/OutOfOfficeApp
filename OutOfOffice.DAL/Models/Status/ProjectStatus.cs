namespace OutOfOffice.DAL
{
    public class ProjectStatus
    {
        public Guid Id { get; set; }

        public string? ProjectStatusName { get; set; }

        public ICollection<Project>? Projects { get; set; }
    }
}