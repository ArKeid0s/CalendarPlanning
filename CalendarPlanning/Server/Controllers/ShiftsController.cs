using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Exceptions.ShiftExceptions;
using CalendarPlanning.Shared.Models.Requests.ShiftRequests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CalendarPlanning.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftsService _shiftService;

        public ShiftsController(IShiftsService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _shiftService.GetShiftsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:guid}", Name = "GetShiftById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var shift = await _shiftService.GetShiftByIdAsync(id);
                return Ok(shift);
            }
            catch (ShiftNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateShift([FromBody] CreateShiftRequest createShiftRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var shift = await _shiftService.CreateShiftAsync(createShiftRequest);
                return CreatedAtRoute("GetShiftById", new { id = shift.ShiftId }, shift);
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
        public async Task<IActionResult> UpdateShift(Guid id, UpdateShiftRequest updateShiftRequest)
        {
            try
            {
                await _shiftService.UpdateShiftAsync(id, updateShiftRequest);
                return NoContent();
            }
            catch (ShiftNotFoundException)
            {
                return NotFound();
            }
            catch (ShiftSaveUpdateException ex)
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
                await _shiftService.DeleteShiftAsync(id);
                return NoContent();
            }
            catch (ShiftNotFoundException)
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
