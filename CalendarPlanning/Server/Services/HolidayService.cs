using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Services
{
    public class HolidayService : IHolidayService
    {
        public Task<bool> CreateHolidayAsync(Holiday Holiday)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteHolidayAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Holiday?> GetHolidayByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Holiday>> GetHolidaysAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateHolidayAsync(Guid id, UpdateHolidayRequest updateHolidayRequest)
        {
            throw new NotImplementedException();
        }
    }
}
