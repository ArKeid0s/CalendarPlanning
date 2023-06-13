using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Shared.ModelExtensions
{
    public static class ShiftExtensions
    {
        public static ShiftDto ToDto(this Shift shift) => new()
        {
            ShiftId = shift.ShiftId,
            HourStart = shift.HourStart,
            HourEnd = shift.HourEnd,
            ShiftType = shift.ShiftType,
        };

        public static Shift ToModel(this ShiftDto shiftDto) => new()
        {
            ShiftId = shiftDto.ShiftId,
            HourStart = shiftDto.HourStart,
            HourEnd = shiftDto.HourEnd,
            ShiftType = shiftDto.ShiftType,
        };
    }
}
