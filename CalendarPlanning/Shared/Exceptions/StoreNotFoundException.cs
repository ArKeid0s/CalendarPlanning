namespace CalendarPlanning.Server.Exceptions
{
    public class StoreNotFoundException : Exception
    {
        public StoreNotFoundException(Guid id) : base($"Store with id {id} not found.")
        {
        }
    }

}
