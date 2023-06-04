using CalendarPlanning.Server.Mapper.Interfaces;
using CalendarPlanning.Server.Mapper.ShiftModelMappers;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Mapper.ScheduleModelMappers
{
    public class ScheduleToScheduleDtoModelMapper : IModelMapper<ScheduleDto, Schedule>
    {
        private readonly ShiftToShiftDtoModelMapper _mapper = new();

        public ScheduleDto Map(Schedule model) => new()
        {
            ScheduleId = model.ScheduleId,
            WeekStart = model.WeekStart,
            WeekEnd = model.WeekEnd,
            Shifts = model.Shifts?.Select(_mapper.Map).ToList()
        };
    }
}
