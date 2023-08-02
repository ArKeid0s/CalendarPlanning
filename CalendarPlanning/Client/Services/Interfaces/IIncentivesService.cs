using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.IncentiveRequests;

namespace CalendarPlanning.Client.Services.Interfaces
{
    public interface IIncentivesService
    {
        List<IncentiveDto>? Incentives { get; }
        event Action? OnIncentivesUpdated;
        Task<HttpResponseMessage> CreateIncentiveAsync(CreateIncentiveRequest createIncentiveRequest);
        Task DeleteIncentiveAsync(string userId, Guid incentiveId);
        Task LoadIncentives();
        Task<(string userId, bool isAdmin)> GetUserRoleDetails();
    }
}
