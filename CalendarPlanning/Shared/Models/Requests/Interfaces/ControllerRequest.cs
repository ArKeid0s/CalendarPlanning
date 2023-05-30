using CalendarPlanning.Server.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CalendarPlanning.Shared.Models.Requests.Interfaces
{
    public class ControllerRequest
    {
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
