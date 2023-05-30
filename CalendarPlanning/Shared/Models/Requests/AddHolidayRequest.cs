namespace CalendarPlanning.Shared.Models.Requests
{
    public class AddHolidayRequest
    {
        public Guid EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
