using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests
{
    public class UpdateShiftRequest
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public Guid ScheduleId { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }
    }
}
