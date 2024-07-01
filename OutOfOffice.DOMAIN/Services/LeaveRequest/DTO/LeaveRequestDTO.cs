using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class LeaveRequestDTO
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string AbsenceReason { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Comment { get; set; } = string.Empty;

        public string RequestStatus { get; set; } = "New";

        public static LeaveRequestDTO LeaveRequestToLeaveRequestDTO(LeaveRequest leaveRequest)
        {
            return new LeaveRequestDTO
            {
                Id = leaveRequest.Id,
                FullName = leaveRequest.Employee?.FullName ?? "Unknown",
                AbsenceReason = leaveRequest.AbsenceReason?.AbsenceReasonName ?? "Unknown",
                StartDate = leaveRequest.StartDate,
                EndDate = leaveRequest.EndDate,
                Comment = leaveRequest.Comment,
                RequestStatus = leaveRequest.RequestStatus?.RequestStatusName ?? "Unknown"
            };
        }
    }
}