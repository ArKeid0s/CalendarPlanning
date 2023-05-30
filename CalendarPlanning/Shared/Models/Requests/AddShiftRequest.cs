namespace CalendarPlanning.Shared.Models.Requests
{
    public class AddShiftRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid ScheduleId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
