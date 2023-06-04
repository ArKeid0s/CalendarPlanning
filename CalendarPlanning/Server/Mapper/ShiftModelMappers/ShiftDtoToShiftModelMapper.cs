using CalendarPlanning.Server.Mapper.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Mapper.ShiftModelMappers
{
    public class ShiftDtoToShiftModelMapper : IModelMapper<Shift, ShiftDto>
    {
        public Shift Map(ShiftDto model) => new()
        {
            ShiftId = model.ShiftId,
            HourStart = model.HourStart,
            HourEnd = model.HourEnd,
            ShiftType = model.ShiftType,
        };
    }
}
