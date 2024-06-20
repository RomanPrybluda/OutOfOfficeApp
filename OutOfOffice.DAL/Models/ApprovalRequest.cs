namespace OutOfOffice.DAL
{
    public class ApprovalRequest
    {
        public Guid Id { get; set; }

        public Guid ApproverId { get; set; }

        public Employee? Approver { get; set; }

        public Guid LeaveRequestId { get; set; }

        public LeaveRequest? LeaveRequest { get; set; }

        public Guid RequestStatusId { get; set; }

        public RequestStatus? RequestStatus { get; set; }

        public string? Comment { get; set; }
    }
}