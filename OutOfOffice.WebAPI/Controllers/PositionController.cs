using Microsoft.AspNetCore.Mvc;
using OutOfOffice.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("Position")]
    public class PositionController : ControllerBase
    {
        private readonly PositionService _positionService;

        public PositionController(PositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPositionsAsync()
        {
            var positions = await _positionService.GetPositionsAsync();
            return Ok(positions);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetPositionByIdAsync([Required] Guid id)
        {
            var position = await _positionService.GetPositionByIdAsync(id);
            return Ok(position);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePositionAsync([Required][FromBody] CreatePositionDTO request)
        {
            var position = await _positionService.CreatePositionAsync(request);
            return Ok(position);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdatePositionAsync([Required] Guid id, [FromBody] UpdatePositionDTO request)
        {
            var position = await _positionService.UpdatePositionAsync(id, request);
            return Ok(position);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeletePositionAsync([Required] Guid id)
        {
            await _positionService.DeletePositionAsync(id);
            return NoContent();
        }
    }
}
