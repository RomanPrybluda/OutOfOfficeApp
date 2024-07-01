namespace OutOfOffice.DOMAIN
{
    public class UpdateProjectDTO
    {
        public string ProjectName { get; set; } = string.Empty;

        public Guid ProjectTypeId { get; set; }

        public Guid ProjectManagerId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid ProjectStatusId { get; set; }

        public string? Comment { get; set; }

    }
}