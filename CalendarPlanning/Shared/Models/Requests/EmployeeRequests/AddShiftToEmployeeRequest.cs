using CalendarPlanning.Shared.Enums;
using CalendarPlanning.Shared.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
