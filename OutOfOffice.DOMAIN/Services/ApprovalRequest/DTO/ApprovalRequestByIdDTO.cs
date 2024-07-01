using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class ApprovalRequestByIdDTO
    {
        public Guid Id { get; set; }

        public string? ApproverFullName { get; set; }

        public Guid LeaveRequestId { get; set; }

        public string RequestStatus { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;

        public static ApprovalRequestByIdDTO ApprovalRequestToApprovalRequestByIdDTO(ApprovalRequest approvalRequest)
        {
            return new ApprovalRequestByIdDTO
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