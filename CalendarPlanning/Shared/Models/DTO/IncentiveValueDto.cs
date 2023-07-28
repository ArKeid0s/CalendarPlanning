namespace CalendarPlanning.Shared.Models.DTO
{
    public class IncentiveValueDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required decimal UnifocalValue { get; set; }
        public required decimal ProgressiveValue { get; set; }
    }
}
