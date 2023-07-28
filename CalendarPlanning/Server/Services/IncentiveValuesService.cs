using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Exceptions.IncentiveExceptions;
using CalendarPlanning.Shared.Exceptions.IncentiveValueExceptions;
using CalendarPlanning.Shared.ModelExtensions;
using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.IncentiveValueRequests;
using static CalendarPlanning.Shared.Exceptions.IncentiveValueExceptions.IncentiveValueNotFoundException;

namespace CalendarPlanning.Server.Services
{
    public class IncentiveValuesService : IIncentiveValuesService
    {
        private readonly IIncentiveValuesRepository _incentiveValuesRepository;

        public IncentiveValuesService(IIncentiveValuesRepository incentiveValuesRepository)
        {
            _incentiveValuesRepository = incentiveValuesRepository;
        }

        public async Task<IncentiveValueDto> GetIncentiveValueByIdAsync(int id)
        {
            return await _incentiveValuesRepository.GetIncentiveValueByIdAsNoTrackingAsync(id);
        }

        public async Task<IEnumerable<IncentiveValueDto>> GetIncentiveValuesAsync()
        {
            return await _incentiveValuesRepository.GetIncentiveValuesAsNoTrackingAsync();
        }

        public async Task UpdateIncentiveValueAsync(int id, UpdateIncentiveValueRequest incentiveValueDto)
        {
            var incentiveDto = await _incentiveValuesRepository.GetIncentiveValueByIdAsNoTrackingAsync(id) ?? throw new IncentiveValueNotFoundException(id);
            incentiveDto.UnifocalValue = incentiveValueDto.UnifocalValue;
            incentiveDto.ProgressiveValue = incentiveValueDto.ProgressiveValue;

            var incentive = incentiveDto.ToModel();

            await _incentiveValuesRepository.UpdateIncentiveValueAsNoTrackingAsync(id, incentive);
        }
    }
}
