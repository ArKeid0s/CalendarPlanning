using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using System.Collections;

namespace CalendarPlanning.Server.Mapper
{
    public class StoreToStoreDtoModelMapper
    {
        private readonly EmployeeToEmployeeDtoModelMapper _mapper = new();

        public StoreDto MapToStoreDto(Store store) => new()
        {
            StoreId = store.StoreId,
            Name = store.Name,
            Address = store.Address,
            Employees = store.Employees?.Select(_mapper.MapToEmployeeDto).ToList(),
        };
    }
}
