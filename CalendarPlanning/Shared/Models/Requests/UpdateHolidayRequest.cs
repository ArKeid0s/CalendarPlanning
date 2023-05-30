namespace CalendarPlanning.Shared.Models.Requests
{
    public class UpdateHolidayRequest
    {
        public Guid EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
