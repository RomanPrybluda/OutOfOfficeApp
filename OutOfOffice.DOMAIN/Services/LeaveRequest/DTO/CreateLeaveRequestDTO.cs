using OutOfOffice.DAL;
using OutOfOffice.DOMAIN;

public class CreateLeaveRequestDTO
{
    public Guid EmployeeId { get; set; }

    public Guid AbsenceReasonId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Comment { get; set; } = string.Empty;

    public Guid RequestStatusId { get; set; }

    public static LeaveRequest ToLeaveRequest(CreateLeaveRequestDTO dto, AppDbContext context)
    {
        var newStatus = context.RequestStatuses
            .FirstOrDefault(rs => rs.RequestStatusName == LeaveRequestStatuses.New.ToString());

        if (newStatus == null)
        {
            throw new CustomException(CustomExceptionType.NotFound, "Request status 'New' not found");
        }

        return new LeaveRequest
        {
            EmployeeId = dto.EmployeeId,
            AbsenceReasonId = dto.AbsenceReasonId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Comment = dto.Comment,
            RequestStatusId = newStatus.Id
        };
    }
}
