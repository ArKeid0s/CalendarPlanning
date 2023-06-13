using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests.EmployeeRequests
{
    public class CreateEmployeeRequest
    {
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public required string StoreName { get; set; }
    }
}
