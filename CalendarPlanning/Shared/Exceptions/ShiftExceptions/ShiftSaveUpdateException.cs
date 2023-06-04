namespace CalendarPlanning.Shared.Exceptions.ShiftExceptions
{
    public class ShiftSaveUpdateException : Exception
    {
        public ShiftSaveUpdateException(Guid id, string message) : base($"Unable to update the shift with id {id} in the database. \nMessage: {message}")
        {
        }
    }
}
