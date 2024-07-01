using Microsoft.AspNetCore.Mvc;
using OutOfOffice.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("approval-request")]
    public class ApprovalRequestController : ControllerBase
    {
        private readonly ApprovalRequestService _approvalRequestService;

        public ApprovalRequestController(ApprovalRequestService approvalRequestService)
        {
            _approvalRequestService = approvalRequestService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllApprovalRequestsAsync()
        {
            var approvalRequests = await _approvalRequestService.GetApprovalRequestsAsync();
            return Ok(approvalRequests);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetByIdApprovalRequestAsync(Guid id)
        {
            var approvalRequest = await _approvalRequestService.GetApprovalRequestByIdAsync(id);
            return Ok(approvalRequest);
        }

        [HttpPost]
        public async Task<ActionResult> CreateApprovalRequestAsync([FromBody] CreateApprovalRequestDTO request)
        {
            var approvalRequest = await _approvalRequestService.CreateApprovalRequestAsync(request);
            return Ok(approvalRequest);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateApprovalRequestAsync([Required] Guid id, [FromBody] UpdateApprovalRequestDTO request)
        {
            var approvalRequest = await _approvalRequestService.UpdateApprovalRequestAsync(id, request);
            return Ok(approvalRequest);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteApprovalRequestAsync([Required] Guid id)
        {
            await _approvalRequestService.DeleteApprovalRequestAsync(id);
            return NoContent();
        }

    }
}