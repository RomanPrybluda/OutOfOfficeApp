namespace OutOfOffice.DAL
{
    public class ApprovalRequest
    {
        public Guid Id { get; set; }

        public Guid? ApproverId { get; set; }

        public Employee Approver { get; set; } = null!;

        public Guid LeaveRequestId { get; set; }

        public LeaveRequest LeaveRequest { get; set; } = null!;

        public Guid RequestStatusId { get; set; }

        public RequestStatus RequestStatus { get; set; } = null!;

        public string Comment { get; set; } = string.Empty;

    }
}