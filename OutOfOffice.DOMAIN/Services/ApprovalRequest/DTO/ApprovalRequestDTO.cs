using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class ApprovalRequestDTO
    {
        public Guid Id { get; set; }

        public string? ApproverFullName { get; set; }

        public Guid LeaveRequestId { get; set; }

        public string RequestStatus { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;

        public static ApprovalRequestDTO ApprovalRequestToApprovalRequestDTO(ApprovalRequest approvalRequest)
        {
            return new ApprovalRequestDTO
            {
                Id = approvalRequest.Id,
                ApproverFullName = approvalRequest.Approver?.FullName,
                LeaveRequestId = approvalRequest.LeaveRequestId,
                RequestStatus = approvalRequest.RequestStatus.RequestStatusName ?? string.Empty,
                Comment = approvalRequest.Comment
            };
        }
    }
}