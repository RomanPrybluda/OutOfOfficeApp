using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class CreatePositionDTO
    {
        public string PositionName { get; set; }

        public static Position CreatePositionFromDTO(CreatePositionDTO createPositionDTO)
        {
            return new Position
            {
                PositionName = createPositionDTO.PositionName
            };
        }
    }
}
