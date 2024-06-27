using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class AbsenceReasonService
    {
        private readonly AppDbContext _context;

        public AbsenceReasonService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AbsenceReasonDTO>> GetAbsenceReasonsAsync()
        {
            var absenceReasons = await _context.AbsenceReasons.ToListAsync();

            if (absenceReasons == null)
                throw new CustomException(CustomExceptionType.NotFound, "Absence reasons weren't found");

            var absenceReasonDTOs = new List<AbsenceReasonDTO>();

            foreach (var absenceReason in absenceReasons)
            {
                var absenceReasonDTO = AbsenceReasonDTO.AbsenceReasonToAbsenceReasonDTO(absenceReason);
                absenceReasonDTOs.Add(absenceReasonDTO);
            }

            return absenceReasonDTOs;
        }

        public async Task<AbsenceReasonByIdDTO> GetAbsenceReasonByIdAsync(Guid id)
        {
            var absenceReason = await _context.AbsenceReasons.FirstOrDefaultAsync(p => p.Id == id);

            if (absenceReason == null)
                throw new CustomException(CustomExceptionType.NotFound, $"Absence reason with id {id} wasn't found.");

            var absenceReasonByIdDTO = AbsenceReasonByIdDTO.AbsenceReasonToAbsenceReasonDTO(absenceReason);

            return absenceReasonByIdDTO;
        }

        public async Task<AbsenceReasonDTO> CreateAbsenceReasonAsync(CreateAbsenceReasonDTO request)
        {
            var existingAbsenceReason = await _context.AbsenceReasons.FirstOrDefaultAsync(p => p.AbsenceReasonName == request.AbsenceReasonName);

            if (existingAbsenceReason != null)
                throw new CustomException(CustomExceptionType.AbsenceReasonAlreadyExists,
                    $"Absence reason with name {request.AbsenceReasonName} already exists.");

            var absenceReason = CreateAbsenceReasonDTO.CreateAbsenceReasonFromDTO(request);

            _context.AbsenceReasons.Add(absenceReason);

            await _context.SaveChangesAsync();

            var createdAbsenceReason = await _context.AbsenceReasons.FindAsync(absenceReason.Id);

            var absenceReasonDTO = AbsenceReasonDTO.AbsenceReasonToAbsenceReasonDTO(createdAbsenceReason);

            return absenceReasonDTO;
        }

        public async Task<AbsenceReasonDTO> UpdateAbsenceReasonAsync(Guid id, UpdateAbsenceReasonDTO request)
        {
            var absenceReason = await _context.AbsenceReasons.FindAsync(id);

            if (absenceReason == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Absence reason with id {id} wasn't found.");

            UpdateAbsenceReasonDTO.UpdateAbsenceReason(absenceReason, request);

            await _context.SaveChangesAsync();

            var updatedAbsenceReasonDTO = AbsenceReasonDTO.AbsenceReasonToAbsenceReasonDTO(absenceReason);

            return updatedAbsenceReasonDTO;
        }

        public async Task DeleteAbsenceReasonAsync(Guid id)
        {
            var absenceReason = await _context.AbsenceReasons.FindAsync(id);

            if (absenceReason == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Absence reason with id {id} wasn't found.");

            _context.AbsenceReasons.Remove(absenceReason);
            await _context.SaveChangesAsync();
        }
    }
}
