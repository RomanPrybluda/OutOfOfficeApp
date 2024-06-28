namespace OutOfOffice.DAL
{
    public class LeaveRequest
    {
        public Guid Id { get; set; }

        public Guid? EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;

        public Guid AbsenceReasonId { get; set; }

        public AbsenceReason AbsenceReason { get; set; } = null!;

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime EndDate { get; set; } = DateTime.UtcNow;

        public string? Comment { get; set; } = string.Empty;

        public Guid RequestStatusId { get; set; }

        public RequestStatus RequestStatus { get; set; } = null!;

        public ApprovalRequest? ApprovalRequest { get; set; }
    }
}