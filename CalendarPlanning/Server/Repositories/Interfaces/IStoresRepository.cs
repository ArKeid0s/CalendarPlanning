using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IStoresRepository
    {
        Task<IEnumerable<Store>> GetStoresAsync();
        Task<Store> GetStoreByIdAsync(Guid id);
        Task<Store> CreateStoreAsync(Store store);
        Task<Store> UpdateStoreAsync(Store store);
        Task<Store> DeleteStoreAsync(Guid id);
    }
}
