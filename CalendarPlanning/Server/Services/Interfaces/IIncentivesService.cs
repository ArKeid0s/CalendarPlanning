using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.IncentiveRequests;

namespace CalendarPlanning.Server.Services.Interfaces
{
    public interface IIncentivesService
    {
        Task<IEnumerable<IncentiveDto>> GetIncentivesAsync();
        Task<IncentiveDto> GetIncentiveByIdAsync(Guid id);
        Task<IncentiveDto> CreateIncentiveAsync(CreateIncentiveRequest createIncentiveRequest);
        Task<IncentiveDto> UpdateIncentiveAsync(Guid id, UpdateIncentiveRequest updateIncentiveRequest);
        Task<IncentiveDto> DeleteIncentiveAsync(Guid id);
    }
}
