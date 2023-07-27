using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Shared.ModelExtensions
{
    public static class ShiftExtensions
    {
        public static ShiftDto ToDto(this Shift shift) => new()
        {
            ShiftId = shift.ShiftId,
            //EmployeeId = shift.EmployeeId,
            HourStart = shift.HourStart,
            HourEnd = shift.HourEnd,
            ShiftType = shift.ShiftType,
        };

        public static Shift ToModel(this ShiftDto shiftDto) => new()
        {
            ShiftId = shiftDto.ShiftId,
            //EmployeeId = shiftDto.EmployeeId,
            HourStart = shiftDto.HourStart,
            HourEnd = shiftDto.HourEnd,
            ShiftType = shiftDto.ShiftType,
        };
    }
}
