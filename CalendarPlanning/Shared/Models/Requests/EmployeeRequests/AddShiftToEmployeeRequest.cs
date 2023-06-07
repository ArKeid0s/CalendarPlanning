using CalendarPlanning.Shared.Enums;
using CalendarPlanning.Shared.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarPlanning.Shared.Models.Requests.EmployeeRequests
{
    public class AddShiftToEmployeeRequest : RequestModelBase
    {
        public required DateTime HourStart { get; set; }
        public required DateTime HourEnd { get; set; }
        public required ShiftTypesEnum ShiftType { get; set; }
    }
}
