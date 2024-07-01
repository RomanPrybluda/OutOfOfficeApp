using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class LeaveRequestService
    {
        private readonly AppDbContext _context;

        public LeaveRequestService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveRequestDTO>> GetLeaveRequestsAsync()
        {
            var leaveRequests = await _context.LeaveRequests
                .Include(lr => lr.Employee)
                .Include(lr => lr.AbsenceReason)
                .Include(lr => lr.RequestStatus)
                .ToListAsync();

            if (leaveRequests == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    "No leave requests found");

            var leaveRequestDTOS = leaveRequests
                .Select(LeaveRequestDTO.LeaveRequestToLeaveRequestDTO)
                .ToList();

            return leaveRequestDTOS;
        }

        public async Task<LeaveRequestByIdDTO> GetLeaveRequestByIdAsync(Guid id)
        {
            var leaveRequest = await _context.LeaveRequests
                .Include(lr => lr.Employee)
                .Include(lr => lr.AbsenceReason)
                .Include(lr => lr.RequestStatus)
                .FirstOrDefaultAsync(lr => lr.Id == id);

            if (leaveRequest == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"No leave request found with id {id}");

            return LeaveRequestByIdDTO.LeaveRequestToLeaveRequestByIdDTO(leaveRequest);
        }

        public async Task<LeaveRequestDTO> CreateLeaveRequestAsync(CreateLeaveRequestDTO dto)
        {
            var employee = await _context.Employees.FindAsync(dto.EmployeeId);

            if (employee == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"No employee found with id {dto.EmployeeId}");

            var absenceReason = await _context.AbsenceReasons.FindAsync(dto.AbsenceReasonId);

            if (absenceReason == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"No absence reason found with id {dto.AbsenceReasonId}");

            var leaveRequest = CreateLeaveRequestDTO.ToLeaveRequest(dto, _context);
            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();

            return LeaveRequestDTO.LeaveRequestToLeaveRequestDTO(leaveRequest);
        }

        public async Task<LeaveRequestDTO> UpdateLeaveRequestAsync(Guid id, UpdateLeaveRequestDTO dto)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);

            if (leaveRequest == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"No leave request found with id {id}");

            UpdateLeaveRequestDTO.UpdateLeaveRequest(leaveRequest, dto);
            await _context.SaveChangesAsync();

            return LeaveRequestDTO.LeaveRequestToLeaveRequestDTO(leaveRequest);
        }

        public async Task DeleteLeaveRequestAsync(Guid id)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);

            if (leaveRequest == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Leave request with id {id} wasn't found.");

            _context.LeaveRequests.Remove(leaveRequest);
            await _context.SaveChangesAsync();
        }
    }
}
