using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Client.Services.Interfaces
{
    public interface IIncentivesService
    {
        Task<(string userId, bool isAdmin)> GetUserRoleDetails();
        Task<List<IncentiveDto>?> LoadIncentivesAsync(bool isAdmin, string userId);
        Task DeleteIncentiveAsync(string userId, Guid incentiveId);
    }
}
