using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CalendarPlanning.Shared.Utils
{
    public class PasswordPolicyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult("Password is required.");

            var passwordRules = new Dictionary<Regex, string>
            {
                { new Regex(@"[0-9]+"), "Password must contain at least one numeric value." },
                { new Regex(@"[A-Z]+"), "Password must contain at least one uppercase letter." },
                { new Regex(@"[a-z]+"), "Password must contain at least one lowercase letter." },
                { new Regex(@"[@$!%*?&]+"), "Password must contain at least one special character." }
            };

            string password = value.ToString()!;

            foreach (var rule in passwordRules)
            {
                if (!rule.Key.IsMatch(password))
                    return new ValidationResult(rule.Value);
            }

            return ValidationResult.Success!;
        }


    }

}
