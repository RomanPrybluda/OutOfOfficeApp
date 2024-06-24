using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class CreateAbsenceReasonDTO
    {
        public string AbsenceReasonName { get; set; }

        public static AbsenceReason CreateAbsenceReasonFromDTO(CreateAbsenceReasonDTO createAbsenceReasonDTO)
        {
            return new AbsenceReason
            {
                AbsenceReasonName = createAbsenceReasonDTO.AbsenceReasonName
            };
        }
    }
}