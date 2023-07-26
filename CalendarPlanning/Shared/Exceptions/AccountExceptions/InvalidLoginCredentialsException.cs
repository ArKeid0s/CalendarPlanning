namespace CalendarPlanning.Shared.Exceptions.AccountExceptions
{
    public class InvalidLoginCredentialsException : Exception
    {
        public InvalidLoginCredentialsException() : base($"Invalid login credentials.")
        {
        }
    }
}
