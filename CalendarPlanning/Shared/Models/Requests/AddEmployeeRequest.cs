using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Shared.Models.Requests.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests
{
    public class AddEmployeeRequest : IEmployeeRequest
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public Guid StoreId { get; set; }

        public void Validate()
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(this, context, results, true);

            if (!isValid)
            {
                throw new InvalidEmployeeRequestException(string.Join(", ", results.Select(r => r.ErrorMessage)));
            }
        }
    }
}
