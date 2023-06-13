using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IShiftsRepository
    {
        Task<IEnumerable<ShiftDto>> GetShiftsAsync();
        Task<IEnumerable<ShiftDto>> GetShiftsAsNoTrackingAsync();
        Task<ShiftDto> GetShiftByIdAsync(Guid id);
        Task<ShiftDto> GetShiftByIdAsNoTrackingAsync(Guid id);
        Task<ShiftDto> CreateShiftAsync(Shift shift);
        Task UpdateShiftAsync(Shift shift);
        Task DeleteShiftAsync(Guid id);
    }
}
