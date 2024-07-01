using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class UpdateApprovalRequestDTO
    {

        public Guid ApproverId { get; set; }

        public string? Comment { get; set; }

        public Guid RequestStatusId { get; set; }

        public static void UpdateApprovalRequest(ApprovalRequest approvalRequest, UpdateApprovalRequestDTO dto)
        {
            approvalRequest.Comment = dto.Comment;
            approvalRequest.RequestStatusId = dto.RequestStatusId;
        }
    }
}