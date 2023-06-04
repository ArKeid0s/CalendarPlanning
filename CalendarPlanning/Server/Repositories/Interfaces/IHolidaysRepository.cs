using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests.HolidayRequests;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IHolidaysRepository
    {
        Task<IEnumerable<Holiday>> GetHolidaysAsync();
        Task<Holiday?> GetHolidayByIdAsync(Guid id);
        Task<bool> CreateHolidayAsync(Holiday Holiday);
        Task<bool> UpdateHolidayAsync(Guid id, UpdateHolidayRequest updateHolidayRequest);
        Task<bool> DeleteHolidayAsync(Guid id);
    }
}
