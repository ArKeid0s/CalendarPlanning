using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Mapper
{
    public class StoreDtoToStoreModelMapper
    {
        public Store MapToStore(StoreDto storeDto) => new()
        {
            StoreId = storeDto.StoreId,
            Name = storeDto.Name,
            Address = storeDto.Address,
        };
    }
}
