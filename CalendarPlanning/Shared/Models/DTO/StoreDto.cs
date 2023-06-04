namespace CalendarPlanning.Shared.Models.DTO
{
    public class StoreDto
    {
        public Guid StoreId { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public List<EmployeeDto>? Employees { get; set; }
    }
}
