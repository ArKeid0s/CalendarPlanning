using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IStoresRepository
    {
        Task<IEnumerable<StoreDto>> GetStoresAsync();
        Task<StoreDto> GetStoreByIdAsync(Guid id);
        Task<StoreDto> CreateStoreAsync(Store store);
        Task<StoreDto> UpdateStoreAsync(Store store);
        Task<StoreDto> DeleteStoreAsync(Guid id);
    }
}
