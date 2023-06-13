using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IStoresRepository
    {
        Task<IEnumerable<StoreDto>> GetStoresAsync();
        Task<StoreDto> GetStoreByIdAsync(Guid id);
        Task<IEnumerable<StoreDto>> GetStoresAsNoTrackingAsync();
        Task<StoreDto> GetStoreByIdAsNoTrackingAsync(Guid id);
        Task<StoreDto> CreateStoreAsync(Store store);
        Task UpdateStoreAsync(Store store);
        Task DeleteStoreAsync(Guid id);
    }
}
