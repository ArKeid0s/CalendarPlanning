using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CalendarPlanning.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoresService _storesService;

        public StoresController(IStoresService storesService)
        {
            _storesService = storesService;
        }

        // GET: api/<StoresController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _storesService.GetStoresAsync());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: api/<StoresController>/{id}
        [HttpGet("{id:guid}", Name = "GetStoreById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var store = await _storesService.GetStoreByIdAsync(id);
                return Ok(store);
            }
            catch (StoreNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/<StoresController>
        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] AddStoreRequest addStoreRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var store = await _storesService.CreateStoreAsync(addStoreRequest);
                return CreatedAtRoute("GetStoreById", new { id = store.StoreId }, store);
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

        // PUT api/<StoresController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStore(Guid id, UpdateStoreRequest updateStoreRequest)
        {
            try
            {
            await _storesService.UpdateStoreAsync(id, updateStoreRequest);
            return NoContent();
            }
            catch (StoreNotFoundException)
            {
                return NotFound();
            }
            catch (StoreSaveUpdateException ex)
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

        // DELETE api/<StoresController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _storesService.DeleteStoreAsync(id);
                return NoContent();
            }
            catch (StoreNotFoundException)
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
