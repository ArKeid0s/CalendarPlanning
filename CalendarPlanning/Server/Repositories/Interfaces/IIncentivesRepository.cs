﻿using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IIncentivesRepository
    {
        Task<IEnumerable<IncentiveDto>> GetIncentivesAsNoTrackingAsync();
        Task<IncentiveDto> GetIncentiveByIdAsNoTrackingAsync(Guid id);
        Task<IncentiveDto> CreateIncentiveAsync(Incentive incentive);
        Task<IncentiveDto> UpdateIncentiveAsync(Incentive incentive);
        Task<IncentiveDto> DeleteIncentiveAsync(Guid id);
    }
}