﻿namespace OutOfOffice.DAL
{
    public class ProjectStatus
    {
        public Guid Id { get; set; }

        public string ProjectStatusName { get; set; } = string.Empty;

        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}