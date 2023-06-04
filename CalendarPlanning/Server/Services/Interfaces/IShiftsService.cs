using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.ShiftRequests;

namespace CalendarPlanning.Server.Services.Interfaces
{
    public interface IShiftsService
    {
        Task<IEnumerable<ShiftDto>> GetShiftsAsync();
        Task<ShiftDto> GetShiftByIdAsync(Guid id);
        Task<ShiftDto> CreateShiftAsync(CreateShiftRequest createShiftRequest);
        Task<ShiftDto> UpdateShiftAsync(Guid id, UpdateShiftRequest updateShiftRequest);
        Task<ShiftDto> DeleteShiftAsync(Guid id);
    }
}
