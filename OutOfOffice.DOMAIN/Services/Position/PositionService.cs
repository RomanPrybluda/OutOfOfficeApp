using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class PositionService
    {
        private readonly AppDbContext _context;

        public PositionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PositionDTO>> GetPositionsAsync()
        {
            var positions = await _context.Positions.ToListAsync();

            if (positions == null)
                throw new CustomException(CustomExceptionType.NotFound, "Positions weren't found");

            var positionDTOs = new List<PositionDTO>();

            foreach (var position in positions)
            {
                var positionDTO = PositionDTO.PositionToPositionDTO(position);
                positionDTOs.Add(positionDTO);
            }

            return positionDTOs;
        }

        public async Task<PositionByIdDTO> GetPositionByIdAsync(Guid id)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(p => p.Id == id);

            if (position == null)
                throw new CustomException(CustomExceptionType.NotFound, $"Position with id {id} wasn't found.");

            var positionByIdDTO = PositionByIdDTO.PositionToPositionDTO(position);

            return positionByIdDTO;
        }

        public async Task<PositionDTO> CreatePositionAsync(CreatePositionDTO request)
        {
            var existingPosition = await _context.Positions.FirstOrDefaultAsync(p => p.PositionName == request.PositionName);

            if (existingPosition != null)
                throw new CustomException(CustomExceptionType.PositionAlreadyExists,
                    $"Position with name {request.PositionName} already exists.");

            var position = CreatePositionDTO.CreatePositionFromDTO(request);

            _context.Positions.Add(position);

            await _context.SaveChangesAsync();

            var createdPosition = await _context.Positions.FindAsync(position.Id);

            var positionDTO = PositionDTO.PositionToPositionDTO(createdPosition);

            return positionDTO;
        }

        public async Task<PositionDTO> UpdatePositionAsync(Guid id, UpdatePositionDTO request)
        {
            var position = await _context.Positions.FindAsync(id);

            if (position == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Position with id {id} wasn't found.");

            UpdatePositionDTO.UpdatePosition(position, request);

            await _context.SaveChangesAsync();

            var updatedPositionDTO = PositionDTO.PositionToPositionDTO(position);

            return updatedPositionDTO;
        }

        public async Task DeletePositionAsync(Guid id)
        {
            var position = await _context.Positions.FindAsync(id);

            if (position == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Position with id {id} wasn't found.");

            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
        }
    }
}
