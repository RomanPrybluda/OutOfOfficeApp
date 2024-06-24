using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class AbsenceReasonDTO
    {
        public Guid Id { get; set; }
        public string AbsenceReasonName { get; set; }

        public static AbsenceReasonDTO AbsenceReasonToAbsenceReasonDTO(AbsenceReason absenceReason)
        {
            return new AbsenceReasonDTO
            {
                Id = absenceReason.Id,
                AbsenceReasonName = absenceReason.AbsenceReasonName
            };
        }
    }
}
