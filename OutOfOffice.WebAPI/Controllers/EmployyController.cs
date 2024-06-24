using Microsoft.AspNetCore.Mvc;
using OutOfOffice.DOMAIN;
using System.ComponentModel.DataAnnotations;


namespace OutOfOffice.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("Employee")]

    public class EmployyController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployyController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployeesAsyncAsync()
        {
            var employees = await _employeeService.GetEmployeesListAsync();
            return Ok(employees);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetEmployeeByIdAsyncAsync([Required] Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmployeeAsyncAsync([Required][FromBody] CreateEmployeeDTO request)
        {
            var employee = await _employeeService.CreateEmployeeAsync(request);
            return Ok(employee);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateEmployeeAsyncAsync([Required] Guid id, [FromBody] UpdateEmployeeDTO request)
        {
            var employee = await _employeeService.UpdateEmployeeAsync(id, request);
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult> DeleteEmployeeAsync([Required] Guid id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
