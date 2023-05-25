namespace CalendarPlanning.Shared.Models.Requests
{
    public class AddEmployeeRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Guid StoreId { get; set; }
    }
}
