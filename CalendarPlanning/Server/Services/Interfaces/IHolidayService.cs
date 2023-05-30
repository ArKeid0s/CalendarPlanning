using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Services.Interfaces
{
    public interface IHolidayService
    {
        Task<IEnumerable<Holiday>> GetHolidaysAsync();
        Task<Holiday?> GetHolidayByIdAsync(Guid id);
        Task<bool> CreateHolidayAsync(Holiday Holiday);
        Task<bool> UpdateHolidayAsync(Guid id, UpdateHolidayRequest updateHolidayRequest);
        Task<bool> DeleteHolidayAsync(Guid id);
    }
}
