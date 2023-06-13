using CalendarPlanning.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests.IncentiveRequests
{
    public class UpdateIncentiveRequest
    {
        [Required]
        [StringLength(50)]
        public required string ClientFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string ClientLastName { get; set; }

        public IncentiveTypeEnum IncentiveUnifocal { get; set; }
        public IncentiveTypeEnum IncentiveProgressive { get; set; }
    }
}
