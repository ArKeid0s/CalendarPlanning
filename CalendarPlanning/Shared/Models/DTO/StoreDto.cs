using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarPlanning.Shared.Models.DTO
{
    public class StoreDto
    {
        public Guid StoreId { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public List<EmployeeDto>? Employees { get; set; }
    }
}
