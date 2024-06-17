using OutOfOffice.DAL.Models;

namespace OutOfOffice.DAL
{
    public class Employee
    {
        public Guid Id { get; set; }

        public AppUser? AppUser { get; set; }

        public string? FullName { get; set; }

        public Guid RoleId { get; set; }

        public Role? Role { get; set; }

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

        //public ICollection<LeaveRequestEntity>? LeaveRequests { get; set; }

        //public ICollection<ProjectEntity>? ManagedProjects { get; set; } 

        //public ICollection<ProjectEntity>? ParticipatedProjects { get; set; }

        //public ICollection<ApprovalRequestEntity>? ApprovalRequests { get; set; }

        public Employee()
        {

        }

        public Employee(AppUser? appUser, string fullName)
        {
            AppUser = appUser;
            FullName = fullName;
        }

    }
}