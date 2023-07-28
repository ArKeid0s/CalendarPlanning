using System.ComponentModel.DataAnnotations;

namespace CalendarPlanning.Shared.Utils
{
    public class PositiveAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is decimal decimalValue)
            {
                return decimalValue >= 0;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The field {name} must be a positive number.";
        }
    }

}
