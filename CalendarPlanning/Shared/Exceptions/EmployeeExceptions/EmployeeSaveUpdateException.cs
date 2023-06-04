namespace CalendarPlanning.Shared.Exceptions.EmployeeExceptions
{
    public class EmployeeSaveUpdateException : Exception
    {
        public EmployeeSaveUpdateException(Guid id, string message) : base($"Unable to update the employee with id {id} in the database. \nMessage: {message}")
        {
        }
    }

}
