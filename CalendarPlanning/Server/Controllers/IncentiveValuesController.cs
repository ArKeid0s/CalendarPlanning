using CalendarPlanning.Server.Authorization;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Exceptions.IncentiveValueExceptions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests.IncentiveValueRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CalendarPlanning.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncentiveValuesController : ControllerBase
    {
        private readonly IIncentiveValuesService _incentiveValuesService;

        public IncentiveValuesController(IIncentiveValuesService incentiveValuesService)
        {
            _incentiveValuesService = incentiveValuesService;
        }

        [Authorize(Policy = Policies.ReadAccess)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncentiveValue>>> GetIncentiveValues()
        {
            try
            {
                return Ok(await _incentiveValuesService.GetIncentiveValuesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize(Policy = Policies.ReadAccess)]
        [HttpGet("{id}")]
        public async Task<ActionResult<IncentiveValue>> GetIncentiveValueById(int id)
        {
            try
            {
                return Ok(await _incentiveValuesService.GetIncentiveValueByIdAsync(id));
            }
            catch (IncentiveValueNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize(Policy = Policies.WriteAccess)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncentiveValue(int id, UpdateIncentiveValueRequest updateIncentiveValueRequest)
        {
            try
            {
                await _incentiveValuesService.UpdateIncentiveValueAsync(id, updateIncentiveValueRequest);
                return NoContent();
            }
            catch (IncentiveValueNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }

}
