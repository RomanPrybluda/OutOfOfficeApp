namespace OutOfOffice.DOMAIN
{
    public class ProjectDTO
    {
        public Guid Id { get; set; }

        public string ProjectName { get; set; }

        public string ProjectTypeName { get; set; }

        public string ProjectManagerFullName { get; set; }

        public string ProjectStatusName { get; set; }

        public string Comment { get; set; }
    }
}