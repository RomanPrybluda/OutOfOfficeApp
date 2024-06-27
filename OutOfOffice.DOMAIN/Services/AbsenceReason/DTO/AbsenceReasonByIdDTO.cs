using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class AbsenceReasonByIdDTO
    {
        public Guid Id { get; set; }

        public string AbsenceReasonName { get; set; }

        public static AbsenceReasonByIdDTO AbsenceReasonToAbsenceReasonDTO(AbsenceReason absenceReason)
        {
            return new AbsenceReasonByIdDTO
            {
                Id = absenceReason.Id,
                AbsenceReasonName = absenceReason.AbsenceReasonName
            };
        }
    }
}
