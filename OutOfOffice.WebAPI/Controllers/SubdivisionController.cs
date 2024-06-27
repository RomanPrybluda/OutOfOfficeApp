using Microsoft.AspNetCore.Mvc;
using OutOfOffice.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("Subdivision")]
    public class SubdivisionController : ControllerBase
    {
        private readonly SubdivisionService _subdivisionService;

        public SubdivisionController(SubdivisionService subdivisionService)
        {
            _subdivisionService = subdivisionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSubdivisionsAsync()
        {
            var subdivisions = await _subdivisionService.GetSubdivisionsAsync();
            return Ok(subdivisions);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetSubdivisionByIdAsync([Required] Guid id)
        {
            var subdivision = await _subdivisionService.GetSubdivisionByIdAsync(id);
            return Ok(subdivision);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubdivisionAsync([Required][FromBody] CreateSubdivisionDTO request)
        {
            var subdivision = await _subdivisionService.CreateSubdivisionAsync(request);
            return Ok(subdivision);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateSubdivisionAsync([Required] Guid id, [FromBody] UpdateSubdivisionDTO request)
        {
            var subdivision = await _subdivisionService.UpdateSubdivisionAsync(id, request);
            return Ok(subdivision);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteSubdivisionAsync([Required] Guid id)
        {
            await _subdivisionService.DeleteSubdivisionAsync(id);
            return NoContent();
        }
    }
}