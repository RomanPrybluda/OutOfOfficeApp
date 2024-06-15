namespace OutOfOffice.DAL
{
    public class ProjectType
    {
        public Guid Id { get; set; }

        public string? ProjectTypeName { get; set; }

        public ICollection<Project>? Projects { get; set; }
    }
}