using Microsoft.AspNetCore.Mvc;
using OutOfOffice.DOMAIN;
using System.ComponentModel.DataAnnotations;


namespace OutOfOffice.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("user")]

    public class AppUserController : ControllerBase
    {
        private readonly AppUserService _appUserService;

        public AppUserController(AppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAppUsersAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var (users, totalUsers) = await _appUserService.GetAppUsersAsync(page, pageSize);
            Response.Headers.Add("X-Total-Count", totalUsers.ToString());
            return Ok(users);
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
