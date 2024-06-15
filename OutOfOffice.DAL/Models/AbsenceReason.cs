namespace OutOfOffice.DAL
{
    public class AbsenceReason
    {
        public Guid Id { get; set; }

        public string? AbsenceReasonName { get; set; }

        public ICollection<LeaveRequest>? LeaveRequests { get; set; }
    }
}