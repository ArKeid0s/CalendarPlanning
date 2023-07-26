namespace CalendarPlanning.Shared.Models
{
    public class LoginResult
    {
        public required bool Succeeded { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }

    public class LogoutResult
    {
        public required bool Succeeded { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class RegisterResult
    {
        public required bool Succeeded { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
