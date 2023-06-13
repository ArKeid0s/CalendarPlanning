using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests.StoreRequests
{
    public class CreateStoreRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}
