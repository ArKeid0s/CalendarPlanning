namespace CalendarPlanning.Shared.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Store? Store { get; set; }
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
    }
}
