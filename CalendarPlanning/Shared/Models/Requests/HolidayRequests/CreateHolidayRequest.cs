using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests.HolidayRequests
{
    public class CreateHolidayRequest
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
