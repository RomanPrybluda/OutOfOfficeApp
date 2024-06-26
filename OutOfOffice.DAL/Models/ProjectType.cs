﻿namespace OutOfOffice.DAL
{
    public class ProjectType
    {
        public Guid Id { get; set; }

        public string ProjectTypeName { get; set; } = string.Empty;

        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}