namespace CalendarPlanning.Shared.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Guid StoreId { get; set; }
        public Store? Store { get; set; }
    }
}
