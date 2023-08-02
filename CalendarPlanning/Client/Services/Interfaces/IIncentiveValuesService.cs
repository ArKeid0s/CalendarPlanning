using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.IncentiveValueRequests;

namespace CalendarPlanning.Client.Services.Interfaces
{
    public interface IIncentiveValuesService
    {
        decimal TotalIndividualIncentiveValue { get; }
        decimal TotalCollectiveIncentiveValue { get; }
        decimal UserIndividualIncentiveValue { get; }
        event Action? OnValuesUpdated;
        void NotifyValuesUpdated();
        Task<bool> UpdateIncentiveValue(int incentiveValueId, UpdateIncentiveValueRequest request);
        void CalculateIncentiveValues();
        void CalculateUserIncentiveValues(string userId);
        Task<List<IncentiveValueDto>?> GetAllAsync();
    }
}
