using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IIncentiveValuesRepository
    {
        Task<IEnumerable<IncentiveValueDto>> GetIncentiveValuesAsNoTrackingAsync();
        Task<IncentiveValueDto> GetIncentiveValueByIdAsNoTrackingAsync(int id);
        Task UpdateIncentiveValueAsNoTrackingAsync(int id, IncentiveValue incentiveValue);
    }
}
