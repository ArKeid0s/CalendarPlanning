namespace CalendarPlanning.Shared.Exceptions.ShiftExceptions
{
    public class ShiftNotFoundException : Exception
    {
        public ShiftNotFoundException(object id) : base($"Shift with id {id} not found.")
        {

        }
    }
}
