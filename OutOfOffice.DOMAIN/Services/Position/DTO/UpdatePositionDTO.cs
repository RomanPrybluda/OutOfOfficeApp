using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class UpdatePositionDTO
    {
        public string PositionName { get; set; }

        public static void UpdatePosition(Position position, UpdatePositionDTO updatePositionDTO)
        {
            position.PositionName = updatePositionDTO.PositionName;
        }
    }
}