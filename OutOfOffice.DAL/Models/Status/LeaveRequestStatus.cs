namespace OutOfOffice.DAL
{
    public class LeaveRequestStatus
    {
        public Guid Id { get; set; }

        public string? LeaveRequestStatusName { get; set; }

        public ICollection<LeaveRequest>? LeaveRequests { get; set; }

        public ICollection<ApprovalRequest>? ApprovalRequests { get; set; }
    }
}