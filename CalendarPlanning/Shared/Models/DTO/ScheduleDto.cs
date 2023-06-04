namespace CalendarPlanning.Shared.Models.DTO
{
    public class ScheduleDto
    {
        public Guid ScheduleId { get; set; }
        public required DateTime WeekStart { get; set; }
        public required DateTime WeekEnd { get; set; }
        public Guid StoreId { get; set; }
        public List<ShiftDto>? Shifts { get; set; }
    }
}
