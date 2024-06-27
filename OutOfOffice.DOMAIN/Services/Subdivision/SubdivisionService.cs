using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class SubdivisionService
    {
        private readonly AppDbContext _context;

        public SubdivisionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubdivisionDTO>> GetSubdivisionsAsync()
        {
            var subdivisions = await _context.Subdivisions.ToListAsync();

            if (subdivisions == null)
                throw new CustomException(CustomExceptionType.NotFound, "Subdivisions weren't found");

            var subdivisionDTOs = new List<SubdivisionDTO>();

            foreach (var subdivision in subdivisions)
            {
                var subdivisionDTO = SubdivisionDTO.SubdivisionToSubdivisionDTO(subdivision);
                subdivisionDTOs.Add(subdivisionDTO);
            }

            return subdivisionDTOs;
        }

        public async Task<SubdivisionByIdDTO> GetSubdivisionByIdAsync(Guid id)
        {
            var subdivision = await _context.Subdivisions.FirstOrDefaultAsync(p => p.Id == id);

            if (subdivision == null)
                throw new CustomException(CustomExceptionType.NotFound, $"Subdivision with id {id} wasn't found.");

            var subdivisionByIdDTO = SubdivisionByIdDTO.SubdivisionToSubdivisionDTO(subdivision);

            return subdivisionByIdDTO;
        }

        public async Task<SubdivisionDTO> CreateSubdivisionAsync(CreateSubdivisionDTO request)
        {
            var existingSubdivision = await _context.Subdivisions.FirstOrDefaultAsync(p => p.SubdivisionName == request.SubdivisionName);

            if (existingSubdivision != null)
                throw new CustomException(CustomExceptionType.SubdivisionAlreadyExists,
                    $"Subdivision with name {request.SubdivisionName} already exists.");

            var subdivision = CreateSubdivisionDTO.CreateSubdivisionFromDTO(request);

            _context.Subdivisions.Add(subdivision);

            await _context.SaveChangesAsync();

            var createdSubdivision = await _context.Subdivisions.FindAsync(subdivision.Id);

            var subdivisionDTO = SubdivisionDTO.SubdivisionToSubdivisionDTO(createdSubdivision);

            return subdivisionDTO;
        }

        public async Task<SubdivisionDTO> UpdateSubdivisionAsync(Guid id, UpdateSubdivisionDTO request)
        {
            var subdivision = await _context.Subdivisions.FindAsync(id);

            if (subdivision == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Subdivision with id {id} wasn't found.");

            UpdateSubdivisionDTO.UpdateSubdivision(subdivision, request);

            await _context.SaveChangesAsync();

            var updatedSubdivisionDTO = SubdivisionDTO.SubdivisionToSubdivisionDTO(subdivision);

            return updatedSubdivisionDTO;
        }

        public async Task DeleteSubdivisionAsync(Guid id)
        {
            var subdivision = await _context.Subdivisions.FindAsync(id);

            if (subdivision == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Subdivision with id {id} wasn't found.");

            _context.Subdivisions.Remove(subdivision);
            await _context.SaveChangesAsync();
        }
    }
}