using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class UpdateAbsenceReasonDTO
    {
        public string AbsenceReasonName { get; set; }

        public static void UpdateAbsenceReason(AbsenceReason absenceReason, UpdateAbsenceReasonDTO updateAbsenceReasonDTO)
        {
            absenceReason.AbsenceReasonName = updateAbsenceReasonDTO.AbsenceReasonName;
        }
    }
}
