namespace CalendarPlanning.Server.Exceptions
{
    public class StoreNotFoundException : Exception
    {
        public StoreNotFoundException(object id) : base($"Store with id {id} not found.")
        {
        }
    }

}
