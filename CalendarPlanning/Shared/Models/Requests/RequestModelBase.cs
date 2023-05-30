using CalendarPlanning.Server.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests
{
    public class RequestModelBase
    {
        public void Validate()
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(this, context, results, true);

            if (!isValid)
            {
                throw new InvalidRequestException(string.Join(", ", results.Select(r => r.ErrorMessage)));
            }
        }
    }
}
