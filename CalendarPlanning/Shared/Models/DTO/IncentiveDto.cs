using CalendarPlanning.Shared.Enums;

namespace CalendarPlanning.Shared.Models.DTO
{
    public class IncentiveDto
    {
        public Guid IncentiveId { get; set; }
        public required string ClientFirstName { get; set; }
        public required string ClientLastName { get; set; }
        public IncentiveTypeEnum IncentiveUnifocal { get; set; }
        public IncentiveTypeEnum IncentiveProgressive { get; set; }
        public required Guid EmployeeId { get; set; }
    }
}