using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests
{
    public class UpdateEmployeeRequest : RequestModelBase
    {
        [Required]
        [MaxLength(50)]
        public required string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        public required string LastName { get; set; }
        
        [Required]
        public required string StoreName { get; set; }
    }
}
