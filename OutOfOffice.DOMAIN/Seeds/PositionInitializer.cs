using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class PositionInitializer
    {
        private readonly AppDbContext _context;

        public PositionInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializePositions()
        {
            var positionNames = Enum.GetNames(typeof(Positions));

            var existingPositions = _context.Positions.Select(p => p.PositionName).ToList();

            foreach (var positionName in positionNames)
            {
                if (!existingPositions.Contains(positionName))
                {
                    _context.Positions.Add(new Position
                    {
                        Id = Guid.NewGuid(),
                        PositionName = positionName
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}