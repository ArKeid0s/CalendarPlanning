using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Store>> GetStoresAsync();
        Task<Store?> GetStoreByIdAsync(Guid id);
        Task<bool> CreateStoreAsync(Store store);
        Task<bool> UpdateStoreAsync(Guid id, UpdateStoreRequest updateStoreRequest);
        Task<bool> DeleteStoreAsync(Guid id);
    }
}
