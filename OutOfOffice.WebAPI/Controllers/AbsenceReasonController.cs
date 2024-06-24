using Microsoft.AspNetCore.Mvc;
using OutOfOffice.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("AbsenceReason")]

    public class AbsenceReasonController : ControllerBase
    {
        private readonly AbsenceReasonService _absenceReasonService;

        public AbsenceReasonController(AbsenceReasonService absenceReasonService)
        {
            _absenceReasonService = absenceReasonService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAbsenceReasonsAsync()
        {
            var absenceReasons = await _absenceReasonService.GetAbsenceReasonsAsync();
            return Ok(absenceReasons);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetAbsenceReasonByIdAsync([Required] Guid id)
        {
            var absenceReason = await _absenceReasonService.GetAbsenceReasonByIdAsync(id);
            return Ok(absenceReason);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAbsenceReasonAsync([Required][FromBody] CreateAbsenceReasonDTO request)
        {
            var absenceReason = await _absenceReasonService.CreateAbsenceReasonAsync(request);
            return Ok(absenceReason);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAbsenceReasonAsync([Required] Guid id, [FromBody] UpdateAbsenceReasonDTO request)
        {
            var absenceReason = await _absenceReasonService.UpdateAbsenceReasonAsync(id, request);
            return Ok(absenceReason);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAbsenceReasonAsync([Required] Guid id)
        {
            await _absenceReasonService.DeleteAbsenceReasonAsync(id);
            return NoContent();
        }
    }
}