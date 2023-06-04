using CalendarPlanning.Server.Mapper.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Mapper.ScheduleModelMappers
{
    public class ScheduleDtoToScheduleModelMapper : IModelMapper<Schedule, ScheduleDto>
    {
        public Schedule Map(ScheduleDto model) => new()
        {
            ScheduleId = model.ScheduleId,
            WeekStart = model.WeekStart,
            WeekEnd = model.WeekEnd,
            StoreId = model.StoreId
        };
    }
}
