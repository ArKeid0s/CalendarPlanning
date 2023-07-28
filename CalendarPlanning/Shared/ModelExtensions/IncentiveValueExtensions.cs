using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Shared.ModelExtensions
{
    public static class IncentiveValueExtensions
    {
        public static IncentiveValueDto ToDto(this IncentiveValue incentiveValue) => new()
        {
            Id = incentiveValue.Id,
            Name = incentiveValue.Name,
            UnifocalValue = incentiveValue.UnifocalValue,
            ProgressiveValue = incentiveValue.ProgressiveValue
        };

        public static IncentiveValue ToModel(this IncentiveValueDto incentiveValueDto) => new()
        {
            Id = incentiveValueDto.Id,
            Name = incentiveValueDto.Name,
            UnifocalValue = incentiveValueDto.UnifocalValue,
            ProgressiveValue = incentiveValueDto.ProgressiveValue
        };
    }
}
