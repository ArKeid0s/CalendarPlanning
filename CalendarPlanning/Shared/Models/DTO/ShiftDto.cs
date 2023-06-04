using CalendarPlanning.Shared.Enums;

namespace CalendarPlanning.Shared.Models.DTO
{
    public class ShiftDto
    {
        public Guid ShiftId { get; set; }
        public required DateTime HourStart { get; set; }
        public required DateTime HourEnd { get; set; }
        public required ShiftTypesEnum ShiftType { get; set; }
    }
}
