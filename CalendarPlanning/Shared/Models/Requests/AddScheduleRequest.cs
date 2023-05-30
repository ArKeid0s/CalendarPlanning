namespace CalendarPlanning.Shared.Models.Requests
{
    public class AddScheduleRequest
    {
        public Guid StoreId { get; set; }
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
    }
}
