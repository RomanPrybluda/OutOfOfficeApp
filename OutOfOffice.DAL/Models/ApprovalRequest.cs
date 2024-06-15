namespace OutOfOffice.DAL
{
    public class ApprovalRequest
    {
        public Guid Id { get; set; }

        public Guid ApproverId { get; set; }

        public Employee? Approver { get; set; }

        public Guid LeaveRequestId { get; set; }

        public LeaveRequest? LeaveRequest { get; set; }

        public Guid LeaveRequestStatusId { get; set; }

        public LeaveRequestStatus? LeaveRequestStatus { get; set; }

        public string? Comment { get; set; }
    }
}