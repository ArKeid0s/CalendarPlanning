using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.IncentiveValueRequests;

namespace CalendarPlanning.Server.Services.Interfaces
{
    public interface IIncentiveValuesService
    {
        Task UpdateIncentiveValueAsync(int id, UpdateIncentiveValueRequest incentiveValueDto);
        Task<IncentiveValueDto> GetIncentiveValueByIdAsync(int id);
        Task<IEnumerable<IncentiveValueDto>> GetIncentiveValuesAsync();
    }
}
