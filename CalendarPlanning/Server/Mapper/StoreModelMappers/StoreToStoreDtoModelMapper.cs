using CalendarPlanning.Server.Mapper.EmployeeModelMappers;
using CalendarPlanning.Server.Mapper.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Mapper.StoreModelMappers
{
    public class StoreToStoreDtoModelMapper : IModelMapper<StoreDto, Store>
    {
        private readonly EmployeeToEmployeeDtoModelMapper _mapper = new();

        public StoreDto Map(Store store) => new()
        {
            StoreId = store.StoreId,
            Name = store.Name,
            Address = store.Address,
            Employees = store.Employees?.Select(_mapper.Map).ToList(),
        };
    }
}
