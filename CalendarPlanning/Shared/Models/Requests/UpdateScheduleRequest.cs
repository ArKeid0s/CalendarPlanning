namespace CalendarPlanning.Shared.Models.Requests
{
    public class UpdateScheduleRequest
    {
        public Guid StoreId { get; set; }
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
    }
}
