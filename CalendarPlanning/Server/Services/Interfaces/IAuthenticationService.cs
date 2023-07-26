using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests.AuthenticationRequests;
using Microsoft.AspNetCore.Identity;

namespace CalendarPlanning.Server.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResult> LoginUserAsync(LoginUserRequest loginUserRequest, SignInManager<ApplicationUser> signInManager, IConfiguration configuration);
        Task<RegisterResult> RegisterUserAsync(RegisterUserRequest registerUserRequest, UserManager<ApplicationUser> userManager);
    }
}
