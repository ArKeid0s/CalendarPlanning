namespace CalendarPlanning.Shared.Models.Requests
{
    public class UpdateEmployeeRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Guid StoreId { get; set; }
    }
}
