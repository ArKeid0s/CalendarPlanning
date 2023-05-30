using CalendarPlanning.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
