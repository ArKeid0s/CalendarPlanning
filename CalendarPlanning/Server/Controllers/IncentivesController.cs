using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Exceptions.IncentiveExceptions;
using CalendarPlanning.Shared.Models.Requests.IncentiveRequests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CalendarPlanning.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncentivesController : ControllerBase
    {
        private readonly IIncentivesService _incentivesService;

        public IncentivesController(IIncentivesService incentivesService)
        {
            _incentivesService = incentivesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _incentivesService.GetIncentivesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //add get with filter from query for employeeId
        
        [HttpGet("{id:guid}", Name = "GetIncentiveById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _incentivesService.GetIncentiveByIdAsync(id));
            }
            catch (IncentiveNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncentive([FromBody] CreateIncentiveRequest createIncentiveRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var incentive = await _incentivesService.CreateIncentiveAsync(createIncentiveRequest);
                return CreatedAtRoute("GetIncentiveById", new { id = incentive.IncentiveId }, incentive);
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

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateIncentive(Guid id, UpdateIncentiveRequest updateIncentiveRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _incentivesService.UpdateIncentiveAsync(id, updateIncentiveRequest);
                return NoContent();
            }
            catch (IncentiveNotFoundException)
            {
                return NotFound();
            }
            catch (IncentiveSaveUpdateException ex)
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

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _incentivesService.DeleteIncentiveAsync(id);
                return NoContent();
            }
            catch (IncentiveNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
