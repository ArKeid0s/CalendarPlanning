using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Models.Requests.AuthenticationRequests
{
    public class LoginUserRequest
    {
        [Required, EmailAddress, Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}
