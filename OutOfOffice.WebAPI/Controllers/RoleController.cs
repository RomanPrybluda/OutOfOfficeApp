using Microsoft.AspNetCore.Mvc;
using OutOfOffice.DOMAIN;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("Role")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRolesAsync()
        {
            var roles = await _roleService.GetRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetRoleByIdAsync([Required] Guid id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoleAsync([Required][FromBody] CreateRoleDTO request)
        {
            var role = await _roleService.CreateRoleAsync(request);
            return Ok(role);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateRoleAsync([Required] Guid id, [FromBody] UpdateRoleDTO request)
        {
            var role = await _roleService.UpdateRoleAsync(id, request);
            return Ok(role);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteRoleAsync([Required] Guid id)
        {
            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}