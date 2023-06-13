using CalendarPlanning.Server.Authorization;
using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Exceptions.EmployeeExceptions;
using CalendarPlanning.Shared.Models.Requests.EmployeeRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CalendarPlanning.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _employeesService.GetEmployeesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: api/<EmployeesController>/{id}
        [Authorize(Policy =Policies.ReadAccess)]
        [HttpGet("{id:guid}", Name = "GetEmployeeById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _employeesService.GetEmployeeByIdAsync(id));
            }
            catch (EmployeeNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/<EmployeesController>
        [Authorize(Policy =Policies.WriteAccess)]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest createEmployeeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var employee = await _employeesService.CreateEmployeeAsync(createEmployeeRequest);
                return CreatedAtRoute("GetEmployeeById", new { id = employee.EmployeeId }, employee);
            }
            catch (InvalidRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        // PUT api/<EmployeesController>/5
        [Authorize(Policy = Policies.WriteAccess)]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _employeesService.UpdateEmployeeAsync(id, updateEmployeeRequest);
                return NoContent();
            }
            catch (EmployeeNotFoundException)
            {
                return NotFound();
            }
            catch (EmployeeSaveUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/<EmployeesController>/5
        [Authorize(Policy = Policies.WriteAccess)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _employeesService.DeleteEmployeeAsync(id);
                return NoContent();
            }
            catch (EmployeeNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize(Policy = Policies.WriteAccess)]
        [HttpPut("{id:guid}/AddShiftToEmployee")]
        public async Task<IActionResult> AddShiftToEmployee(Guid id, AddShiftToEmployeeRequest addShiftToEmployeeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _employeesService.AddShiftToEmployeeAsync(id, addShiftToEmployeeRequest);
                return NoContent();
            }
            catch (EmployeeNotFoundException)
            {
                return NotFound();
            }
            catch (EmployeeSaveUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}