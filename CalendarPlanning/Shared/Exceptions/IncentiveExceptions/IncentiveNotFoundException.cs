namespace CalendarPlanning.Shared.Exceptions.IncentiveExceptions
{
    public class IncentiveNotFoundException : Exception
    {
        public IncentiveNotFoundException(Guid id) : base($"Incentive with id {id} not found.")
        {
        }
    }
}
