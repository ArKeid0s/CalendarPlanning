using CalendarPlanning.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests.IncentiveRequests
{
    public class CreateIncentiveRequest
    {
        [Required]
        [StringLength(50)]
        public string ClientFirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string ClientLastName { get; set; } = string.Empty;
        
        public IncentiveTypeEnum IncentiveUnifocal { get; set; }
        public IncentiveTypeEnum IncentiveProgressive { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
    }
}
