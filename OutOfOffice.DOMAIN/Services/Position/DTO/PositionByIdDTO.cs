using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class PositionByIdDTO
    {
        public Guid Id { get; set; }

        public string PositionName { get; set; }

        public static PositionByIdDTO PositionToPositionDTO(Position position)
        {
            return new PositionByIdDTO
            {
                Id = position.Id,
                PositionName = position.PositionName
            };
        }
    }
}
