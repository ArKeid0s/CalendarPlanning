using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IShiftsRepository
    {
        Task<IEnumerable<Shift>> GetShiftsAsync();
        Task<Shift?> GetShiftByIdAsync(Guid id);
        Task<bool> CreateShiftAsync(Shift shift);
        Task<bool> UpdateShiftAsync(Guid id, UpdateShiftRequest updateShiftRequest);
        Task<bool> DeleteShiftAsync(Guid id);
    }
}
