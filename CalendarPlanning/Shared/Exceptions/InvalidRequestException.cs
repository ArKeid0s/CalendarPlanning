namespace CalendarPlanning.Server.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string fieldName) : base($"Invalid request. The field '{fieldName}' is invalid.") { }
    }
}
