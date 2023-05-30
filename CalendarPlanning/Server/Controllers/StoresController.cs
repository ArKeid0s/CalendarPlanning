using CalendarPlanning.Server.Services;
using CalendarPlanning.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalendarPlanning.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoresService _storeService;

        public StoresController(IStoresService storeService)
        {
            _storeService = storeService;
        }

        // GET: api/<StoresController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _storeService.GetStoresAsync());
        }
    }
}
