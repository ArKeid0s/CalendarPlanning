namespace CalendarPlanning.Shared.Models.DTO
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public Guid StoreId { get; set; }
        public required string StoreName { get; set; }
        public required string StoreAddress { get; set; }
        public required List<ShiftDto>? Shifts { get; set; }
    }
}
