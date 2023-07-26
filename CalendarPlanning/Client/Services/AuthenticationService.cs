using Blazored.LocalStorage;
using CalendarPlanning.Client.Services.Interfaces;
using CalendarPlanning.Client.Utils;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests.AuthenticationRequests;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace CalendarPlanning.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResult> Login(LoginUserRequest loginUserRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/authentication/login", loginUserRequest);

            var loginResult = JsonSerializer.Deserialize<LoginResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!response.IsSuccessStatusCode)
            {
                return loginResult!;
            }

            await _localStorage.SetItemAsync("authToken", loginResult!.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginResult.Token);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);
            
            return loginResult;
        }

        public async Task<LogoutResult> Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
            return new LogoutResult { Succeeded = true };
        }

        public async Task<RegisterResult> Register(RegisterUserRequest registerUserRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/authentication/register", registerUserRequest);

            var registerResult = JsonSerializer.Deserialize<RegisterResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return registerResult!;
        }
    }
}
