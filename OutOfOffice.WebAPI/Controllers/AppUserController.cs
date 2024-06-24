using Microsoft.AspNetCore.Mvc;
using OutOfOffice.DOMAIN;
using System.ComponentModel.DataAnnotations;


namespace OutOfOffice.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("AppUser")]

    public class AppUserController : ControllerBase
    {
        private readonly AppUserService _appUserService;

        public AppUserController(AppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAppUsersAsyncAsync()
        {
            var employees = await _appUserService.GetAppUsersAsync();
            return Ok(employees);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetAppUserByIdAsyncAsync([Required] Guid id)
        {
            var employee = await _appUserService.GetAppUserByIdAsync(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAppUserAsync([Required][FromBody] CreateAppUserDTO request)
        {
            var employee = await _appUserService.CreateAppUserAsync(request);
            return Ok(employee);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAppUserAsync([Required] Guid id, [FromBody] UpdateAppUserDTO request)
        {
            var employee = await _appUserService.UpdateAppUserAsync(id, request);
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult> DeleteAppUserAsync([Required] Guid id)
        {
            await _appUserService.DeleteAppUserAsync(id);
            return NoContent();
        }
    }
}
