using CalendarPlanning.Shared.Models.Requests.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests
{
    public class UpdateHolidayRequest : ControllerRequest
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
