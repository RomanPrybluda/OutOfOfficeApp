using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class CreateApprovalRequestDTO
    {

        public Guid ApproverId { get; set; }

        public Guid LeaveRequestId { get; set; }

        public string? Comment { get; set; } = string.Empty;

        public Guid RequestStatusId { get; set; }

        public static ApprovalRequest CreateApprovalRequestDTOToApprovalRequest(CreateApprovalRequestDTO dto)
        {
            return new ApprovalRequest
            {
                Id = Guid.NewGuid(),
                ApproverId = dto.ApproverId,
                LeaveRequestId = dto.LeaveRequestId,
                Comment = dto.Comment,
                RequestStatusId = dto.RequestStatusId
            };
        }

    }
}