namespace OutOfOffice.DAL
{
    public class RequestStatus
    {
        public Guid Id { get; set; }

        public string? RequestStatusName { get; set; }

        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

        public ICollection<ApprovalRequest> ApprovalRequests { get; set; } = new List<ApprovalRequest>();
    }
}