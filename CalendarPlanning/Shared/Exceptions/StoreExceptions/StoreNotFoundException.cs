namespace CalendarPlanning.Shared.Exceptions.StoreExceptions
{
    public class StoreNotFoundException : Exception
    {
        public StoreNotFoundException(object id) : base($"Store with id {id} not found.")
        {
        }
    }

}
