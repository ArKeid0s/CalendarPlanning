using CalendarPlanning.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests.ShiftRequests
{
    public class CreateShiftRequest
    {
        [Required]
        public required string EmployeeId { get; set; }

        [Required]
        public required DateTime HourStart { get; set; }

        [Required]
        public required DateTime HourEnd { get; set; }

        [Required]
        public required ShiftTypesEnum ShiftType { get; set; }
    }
}
