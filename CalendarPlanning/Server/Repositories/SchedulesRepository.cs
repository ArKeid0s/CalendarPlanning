using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests.ScheduleRequests;

namespace CalendarPlanning.Server.Repositories
{
    public class SchedulesRepository : ISchedulesRepository
    {
        public Task<bool> CreateScheduleAsync(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteScheduleAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule?> GetScheduleByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Schedule>> GetSchedulesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateScheduleAsync(Guid id, UpdateScheduleRequest updateScheduleRequest)
        {
            throw new NotImplementedException();
        }
    }
}
