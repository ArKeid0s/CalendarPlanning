using CalendarPlanning.Server.Mapper.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Mapper.StoreModelMappers
{
    public class StoreDtoToStoreModelMapper : IModelMapper<Store, StoreDto>
    {
        public Store Map(StoreDto storeDto) => new()
        {
            StoreId = storeDto.StoreId,
            Name = storeDto.Name,
            Address = storeDto.Address,
        };
    }
}
