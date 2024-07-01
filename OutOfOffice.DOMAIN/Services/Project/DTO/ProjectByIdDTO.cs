namespace OutOfOffice.DOMAIN
{
    public class ProjectByIdDTO
    {
        public Guid Id { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public string ProjectTypeName { get; set; } = string.Empty;

        public string ProjectManagerFullName { get; set; } = string.Empty;

        public string ProjectStatusName { get; set; } = string.Empty;

        public string? Comment { get; set; }
    }
}