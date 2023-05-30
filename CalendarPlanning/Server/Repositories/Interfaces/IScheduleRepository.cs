using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetSchedulesAsync();
        Task<Schedule?> GetScheduleByIdAsync(Guid id);
        Task<bool> CreateScheduleAsync(Schedule schedule);
        Task<bool> UpdateScheduleAsync(Guid id, UpdateScheduleRequest updateScheduleRequest);
        Task<bool> DeleteScheduleAsync(Guid id);
    }
}
