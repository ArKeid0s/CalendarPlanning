using System.Net.Http.Json;
using System.Security.Claims;
using CalendarPlanning.Client.Services.Interfaces;
using CalendarPlanning.Shared.Models.DTO;
using Microsoft.AspNetCore.Components.Authorization;

namespace CalendarPlanning.Client.Services
{
    public class IncentivesService : IIncentivesService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public IncentivesService(HttpClient http, AuthenticationStateProvider authenticationStateProvider)
        {
            _http = http;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task DeleteIncentiveAsync(string userId, Guid incentiveId)
        {
            try
            {
                await _http.DeleteAsync($"api/Incentives/IncentivesOfUser/{userId}/{incentiveId}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(string userId, bool isAdmin)> GetUserRoleDetails()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity!.IsAuthenticated)
            {
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                var isAdmin = user.IsInRole("Admin");

                return (userId, isAdmin);
            }

            throw new Exception("User is not authenticated");
        }

        public async Task<List<IncentiveDto>?> LoadIncentivesAsync(bool isAdmin, string userId)
        {
            if (isAdmin)
            {
                try
                {
                    return await _http.GetFromJsonAsync<List<IncentiveDto>>("api/Incentives");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                try
                {
                    return await _http.GetFromJsonAsync<List<IncentiveDto>>($"api/Incentives/IncentivesOfUser/{userId}");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
