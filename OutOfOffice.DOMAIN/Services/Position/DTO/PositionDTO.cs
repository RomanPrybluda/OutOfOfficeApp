using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class PositionDTO
    {
        public Guid Id { get; set; }
        public string PositionName { get; set; }

        public static PositionDTO PositionToPositionDTO(Position position)
        {
            return new PositionDTO
            {
                Id = position.Id,
                PositionName = position.PositionName
            };
        }
    }
}
