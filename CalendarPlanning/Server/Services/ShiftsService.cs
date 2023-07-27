using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.ModelExtensions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.ShiftRequests;

namespace CalendarPlanning.Server.Services
{
    public class ShiftsService : IShiftsService
    {
        private readonly IShiftsRepository _shiftsRepository;

        public ShiftsService(IShiftsRepository shiftsRepository) 
        {
            _shiftsRepository = shiftsRepository;
        }

        public async Task<ShiftDto> CreateShiftAsync(CreateShiftRequest createShiftRequest)
        {
            var shift = new Shift()
            {
                //EmployeeId = createShiftRequest.EmployeeId,
                HourStart = createShiftRequest.HourStart,
                HourEnd = createShiftRequest.HourEnd,
                ShiftType = createShiftRequest.ShiftType,
            };

            return await _shiftsRepository.CreateShiftAsync(shift);
        }

        public async Task DeleteShiftAsync(Guid id)
        {
            await _shiftsRepository.DeleteShiftAsync(id);
        }

        public async Task<ShiftDto> GetShiftByIdAsync(Guid id)
        {
            return await _shiftsRepository.GetShiftByIdAsNoTrackingAsync(id);
        }

        public async Task<IEnumerable<ShiftDto>> GetShiftsAsync()
        {
            return await _shiftsRepository.GetShiftsAsNoTrackingAsync();
        }

        public async Task UpdateShiftAsync(Guid id, UpdateShiftRequest updateShiftRequest)
        {
            var shiftDto = await _shiftsRepository.GetShiftByIdAsNoTrackingAsync(id);
            shiftDto.HourStart = updateShiftRequest.HourStart;
            shiftDto.HourEnd = updateShiftRequest.HourEnd;
            shiftDto.ShiftType = updateShiftRequest.ShiftType;

            var shift = shiftDto.ToModel();

            await _shiftsRepository.UpdateShiftAsync(shift);
        }
    }
}
