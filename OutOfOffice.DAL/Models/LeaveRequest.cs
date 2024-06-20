namespace OutOfOffice.DAL
{
    public class LeaveRequest
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        public Guid AbsenceReasonId { get; set; }

        public AbsenceReason? AbsenceReason { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime EndDate { get; set; } = DateTime.UtcNow;

        public string? Comment { get; set; }

        public Guid RequestStatusId { get; set; }

        public RequestStatus? RequestStatus { get; set; }

        public ApprovalRequest? CurrentApprovalRequest { get; set; }
    }
}