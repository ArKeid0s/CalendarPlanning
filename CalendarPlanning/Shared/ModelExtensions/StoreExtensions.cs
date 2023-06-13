using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Shared.ModelExtensions
{
    public static class StoreExtensions
    {
        public static StoreDto ToDto(this Store store) => new()
        {
            StoreId = store.StoreId,
            Name = store.Name,
            Address = store.Address,
            Employees = store.Employees?.Select(e => e.ToDto()).ToList()
        };

        public static Store ToModel(this StoreDto storeDto) => new()
        {
            StoreId = storeDto.StoreId,
            Name = storeDto.Name,
            Address = storeDto.Address
        };
    }
}
