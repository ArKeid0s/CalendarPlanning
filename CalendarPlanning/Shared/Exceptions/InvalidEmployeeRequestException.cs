namespace CalendarPlanning.Server.Exceptions
{
    public class InvalidEmployeeRequestException : Exception
    {
        public InvalidEmployeeRequestException(string fieldName) : base($"Invalid request. The field '{fieldName}' is invalid.") { }
    }
}
