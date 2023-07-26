namespace CalendarPlanning.Shared.Exceptions.AccountExceptions
{
    public class UserRegistrationFailedException : Exception
    {
        public UserRegistrationFailedException() : base("User registration failed.")
        {
        }
    }
}
