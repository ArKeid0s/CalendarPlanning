using CalendarPlanning.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests.EmployeeRequests
{
    public class AddShiftToEmployeeRequest
    {
        [Required]
        public required DateTime HourStart { get; set; }

        [Required]
        public required DateTime HourEnd { get; set; }

        [Required]
        public required ShiftTypesEnum ShiftType { get; set; }
    }
}
