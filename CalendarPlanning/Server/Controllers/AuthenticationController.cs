using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests.AuthenticationRequests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CalendarPlanning.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _accountsService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationController(IAuthenticationService accountsService, IConfiguration configuration, ILogger<AuthenticationController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _accountsService = accountsService;
            _configuration = configuration;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest registerUserRequest)
        {
            var result = await _accountsService.RegisterUserAsync(registerUserRequest, _userManager);

            if (!result.Succeeded)
            {
                _logger.LogError("Error while registering user on machine {Machine}. TraceId: {TraceId}", Environment.MachineName, Activity.Current?.TraceId);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserRequest loginUserRequest)
        {
            var result = await _accountsService.LoginUserAsync(loginUserRequest, _signInManager, _configuration);

            if (!result.Succeeded)
            {
                _logger.LogError("Error while logging in user on machine {Machine}. TraceId: {TraceId}", Environment.MachineName, Activity.Current?.TraceId);
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
