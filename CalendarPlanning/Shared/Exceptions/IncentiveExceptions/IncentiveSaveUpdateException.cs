namespace CalendarPlanning.Shared.Exceptions.IncentiveExceptions
{
    public class IncentiveSaveUpdateException : Exception
    {
        public IncentiveSaveUpdateException(Guid id, string message) : base($"Unable to update the incentive with id {id} in the database. \nMessage: {message}")
        {
        }
    }
}
