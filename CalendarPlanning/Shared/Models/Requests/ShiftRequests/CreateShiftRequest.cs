using CalendarPlanning.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests.ShiftRequests
{
    public class CreateShiftRequest : RequestModelBase
    {
        [Required]
        public DateTime HourStart { get; set; }

        [Required]
        public DateTime HourEnd { get; set; }

        [Required]
        public ShiftTypesEnum ShiftType { get; set; }
    }
}
