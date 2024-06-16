namespace OutOfOffice.DAL
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string? FullName { get; set; }

        public Guid SubdivisionId { get; set; }
        public Subdivision? Subdivision { get; set; }

        public Guid PositionId { get; set; }
        public Position? Position { get; set; }

        public Guid EmployeeStatusId { get; set; }
        public EmployeeStatus? EmployeeStatus { get; set; }

        public Guid PeoplePartnerId { get; set; }
        public Employee? PeoplePartner { get; set; }

        public int OutOfOfficeBalance { get; set; }

        public string? Photo { get; set; }

        public ICollection<LeaveRequest>? LeaveRequests { get; set; }
        public ICollection<Project>? ManagedProjects { get; set; } // Projects managed by this employee
        public ICollection<Project>? ParticipatedProjects { get; set; } // Projects this employee participates in
        public ICollection<ApprovalRequest>? ApprovalRequests { get; set; }
    }
}