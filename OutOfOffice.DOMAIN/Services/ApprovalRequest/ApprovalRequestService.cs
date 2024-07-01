using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class ApprovalRequestService
    {
        private readonly AppDbContext _context;

        public ApprovalRequestService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApprovalRequestDTO>> GetApprovalRequestsAsync()
        {
            var approvalRequests = await _context.ApprovalRequests
                .Include(ar => ar.Approver)
                .Include(ar => ar.LeaveRequest)
                .Include(ar => ar.RequestStatus)
                .ToListAsync();

            if (approvalRequests == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    "No approval requests found");

            var approvalRequestDTOs = new List<ApprovalRequestDTO>();

            foreach (var approvalRequest in approvalRequests)
            {
                var approvalRequestDTO = ApprovalRequestDTO
                    .ApprovalRequestToApprovalRequestDTO(approvalRequest);
                approvalRequestDTOs.Add(approvalRequestDTO);
            }

            return approvalRequestDTOs;
        }

        public async Task<ApprovalRequestByIdDTO> GetApprovalRequestByIdAsync(Guid id)
        {
            var approvalRequest = await _context.ApprovalRequests
                .Include(ar => ar.Approver)
                .Include(ar => ar.LeaveRequest)
                .Include(ar => ar.RequestStatus)
                .FirstOrDefaultAsync(ar => ar.Id == id);

            if (approvalRequest == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    "Approval request with id {id} wasn't found");

            var approvalRequestByIdDTO = ApprovalRequestByIdDTO
                .ApprovalRequestToApprovalRequestByIdDTO(approvalRequest);

            return approvalRequestByIdDTO;
        }


        public async Task<ApprovalRequestDTO> CreateApprovalRequestAsync(CreateApprovalRequestDTO request)
        {
            var approver = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == request.ApproverId);

            if (approver == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"No employee found with id {request.ApproverId}");

            var existingLeaveRequest = await _context.LeaveRequests
                .FirstOrDefaultAsync(lr => lr.Id == request.LeaveRequestId);

            if (existingLeaveRequest == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"No leave request found with id {request.LeaveRequestId}");

            var approvalRequest = CreateApprovalRequestDTO
                .CreateApprovalRequestDTOToApprovalRequest(request);

            _context.ApprovalRequests.Add(approvalRequest);

            await _context.SaveChangesAsync();

            var createdApprovalRequest = await _context.ApprovalRequests
                .FindAsync(approvalRequest.Id);

            var approvalRequestDTO = ApprovalRequestDTO
                .ApprovalRequestToApprovalRequestDTO(createdApprovalRequest);

            return approvalRequestDTO;
        }

        public async Task<ApprovalRequestDTO> UpdateApprovalRequestAsync(Guid id, UpdateApprovalRequestDTO request)
        {
            var approvalRequest = await _context.ApprovalRequests.FindAsync(id);

            if (approvalRequest == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Approval Request with id {id} wasn't found");

            var approver = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == approvalRequest.ApproverId);

            if (approver == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Approver with id {approver.Id} wasn't found.");

            UpdateApprovalRequestDTO.UpdateApprovalRequest(approvalRequest, request);

            await _context.SaveChangesAsync();

            var updatedApprovalRequest = await _context.ApprovalRequests
                .Include(ar => ar.Approver)
                .Include(ar => ar.LeaveRequest)
                .Include(ar => ar.RequestStatus)
                .FirstOrDefaultAsync(ar => ar.Id == id);

            var updatedApprovalRequestDTO = ApprovalRequestDTO
                .ApprovalRequestToApprovalRequestDTO(updatedApprovalRequest);

            return updatedApprovalRequestDTO;
        }

        public async Task DeleteApprovalRequestAsync(Guid id)
        {
            var approvalRequest = await _context.ApprovalRequests.FindAsync(id);

            if (approvalRequest == null)
                throw new CustomException(CustomExceptionType.NotFound,
                  $"Approval Request with id {id} wasn't found");

            _context.ApprovalRequests.Remove(approvalRequest);
            await _context.SaveChangesAsync();
        }

    }
}
