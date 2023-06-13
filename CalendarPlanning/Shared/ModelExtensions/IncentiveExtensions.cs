using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Shared.ModelExtensions
{
    public static class IncentiveExtensions
    {
        public static IncentiveDto ToDto(this Incentive incentive) => new()
        {
            IncentiveId = incentive.IncentiveId,
            ClientFirstName = incentive.ClientFirstName,
            ClientLastName = incentive.ClientLastName,
            IncentiveUnifocal = incentive.IncentiveUnifocal,
            IncentiveProgressive = incentive.IncentiveProgressive,
            EmployeeId = incentive.EmployeeId
        };

        public static Incentive ToModel(this IncentiveDto incentiveDto) => new()
        {
            IncentiveId = incentiveDto.IncentiveId,
            ClientFirstName = incentiveDto.ClientFirstName,
            ClientLastName = incentiveDto.ClientLastName,
            IncentiveUnifocal = incentiveDto.IncentiveUnifocal,
            IncentiveProgressive = incentiveDto.IncentiveProgressive,
            EmployeeId = incentiveDto.EmployeeId
        };
    }
}
