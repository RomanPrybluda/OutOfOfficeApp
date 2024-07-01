using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class UpdateLeaveRequestDTO
    {
        public Guid AbsenceReasonId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Comment { get; set; } = string.Empty;

        public Guid RequestStatusId { get; set; }

        public static void UpdateLeaveRequest(LeaveRequest leaveRequest, UpdateLeaveRequestDTO dto)
        {
            leaveRequest.AbsenceReasonId = dto.AbsenceReasonId;
            leaveRequest.StartDate = dto.StartDate;
            leaveRequest.EndDate = dto.EndDate;
            leaveRequest.Comment = dto.Comment;
            leaveRequest.RequestStatusId = dto.RequestStatusId;
        }
    }
}