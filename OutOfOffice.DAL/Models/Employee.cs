using OutOfOffice.DAL;

public class Employee
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public int OutOfOfficeBalance { get; set; }

    public byte[] Photo { get; set; }

    public Guid? AppUserId { get; set; }

    public AppUser? AppUser { get; set; }

    public Guid SubdivisionId { get; set; }

    public Subdivision? Subdivision { get; set; }

    public Guid PositionId { get; set; }

    public Position Position { get; set; }

    public Guid EmployeeStatusId { get; set; }

    public EmployeeStatus? EmployeeStatus { get; set; }

    public Guid? PeoplePartnerId { get; set; }

    public Employee? PeoplePartner { get; set; }

    public ICollection<LeaveRequest>? LeaveRequests { get; set; } = new List<LeaveRequest>();

    public ICollection<ApprovalRequest> ApprovalRequests { get; set; } = new List<ApprovalRequest>();

    public ICollection<ProjectEmployee> Projects { get; set; } = new List<ProjectEmployee>();

    public Project ManagedProject { get; set; } = null!;

    public Employee() { }

    public Employee(AppUser? appUser, string fullName)
    {
        AppUser = appUser;
        FullName = fullName;
    }
}
