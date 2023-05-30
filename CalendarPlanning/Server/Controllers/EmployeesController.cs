using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CalendarPlanning.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeService.GetEmployeesAsync());
        }

        // GET: api/<EmployeesController>/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] AddEmployeeRequest addEmployeeRequest)
        {
            var result = await _employeeService.CreateEmployeeAsync(addEmployeeRequest);

            return result ? Ok() : StatusCode((int)HttpStatusCode.InternalServerError);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var result = await _employeeService.UpdateEmployeeAsync(id, updateEmployeeRequest);

            return result ? Ok(result) : NotFound(); // TODO: return created at route
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);

            return result ? Ok(result) : NotFound();
        }
    }
}
