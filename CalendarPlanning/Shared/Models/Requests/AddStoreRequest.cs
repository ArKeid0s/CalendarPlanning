using CalendarPlanning.Shared.Models.Requests.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests
{
    public class AddStoreRequest : ControllerRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}
