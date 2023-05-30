using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Shared.Models.Requests.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests
{
    public class AddEmployeeRequest : ControllerRequest
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public Guid StoreId { get; set; }
    }
}
