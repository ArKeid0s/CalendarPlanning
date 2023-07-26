using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests.AuthenticationRequests;

namespace CalendarPlanning.Client.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResult> Login(LoginUserRequest loginModel);
        Task<LogoutResult> Logout();
        Task<RegisterResult> Register(RegisterUserRequest registerModel);
    }
}
