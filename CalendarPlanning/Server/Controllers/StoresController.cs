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
            return Ok(await _storesService.GetStoresAsync());
        }

        // GET: api/<StoresController>/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var store = await _storesService.GetStoreByIdAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        // POST api/<StoresController>
        [HttpPost]
        public async Task<IActionResult> CreateStores([FromBody] AddStoreRequest addStoreRequest)
        {
            var result = await _storesService.CreateStoreAsync(addStoreRequest);

            return result ? Ok() : StatusCode((int)HttpStatusCode.InternalServerError);
        }

        // PUT api/<StoresController>/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStore(Guid id, UpdateStoreRequest updateStoreRequest)
        {
            var result = await _storesService.UpdateStoreAsync(id, updateStoreRequest);

            return result ? Ok(result) : NotFound(); // TODO: return created at route
        }

        // DELETE api/<StoresController>/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _storesService.DeleteStoreAsync(id);

            return result ? Ok(result) : NotFound();
        }
    }
}
