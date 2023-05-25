namespace CalendarPlanning.Shared.Models
{
    public class Shift
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public Guid ScheduleId { get; set; }
        public Schedule? Schedule { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
