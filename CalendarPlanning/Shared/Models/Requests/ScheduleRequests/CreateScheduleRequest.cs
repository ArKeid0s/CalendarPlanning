using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests.ScheduleRequests
{
    public class CreateScheduleRequest
    {
        [Required]
        public Guid StoreId { get; set; }

        [Required]
        public DateTime WeekStart { get; set; }

        [Required]
        public DateTime WeekEnd { get; set; }
    }
}
