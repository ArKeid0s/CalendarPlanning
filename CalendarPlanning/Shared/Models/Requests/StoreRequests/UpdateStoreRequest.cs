using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests.StoreRequests
{
    public class UpdateStoreRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}
