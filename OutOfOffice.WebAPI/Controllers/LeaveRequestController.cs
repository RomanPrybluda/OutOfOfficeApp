using Microsoft.AspNetCore.Mvc;
using OutOfOffice.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("leave-request")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly LeaveRequestService _leaveRequestService;

        public LeaveRequestController(LeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllLeaveRequestsAsync()
        {
            var leaveRequests = await _leaveRequestService.GetLeaveRequestsAsync();
            return Ok(leaveRequests);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetLeaveRequestByIdAsync([Required] Guid id)
        {
            var leaveRequest = await _leaveRequestService.GetLeaveRequestByIdAsync(id);
            return Ok(leaveRequest);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLeaveRequestAsync([Required][FromBody] CreateLeaveRequestDTO request)
        {
            var leaveRequest = await _leaveRequestService.CreateLeaveRequestAsync(request);
            return Ok(leaveRequest);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateLeaveRequestAsync([Required] Guid id, [FromBody] UpdateLeaveRequestDTO request)
        {
            var leaveRequest = await _leaveRequestService.UpdateLeaveRequestAsync(id, request);
            return Ok(leaveRequest);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteLeaveRequestAsync([Required] Guid id)
        {
            await _leaveRequestService.DeleteLeaveRequestAsync(id);
            return NoContent();
        }
    }
}
