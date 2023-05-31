using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Services.Interfaces
{
    public interface IStoresService
    {
        Task<IEnumerable<Store>> GetStoresAsync();
        Task<Store> GetStoreByIdAsync(Guid id);
        Task<Store> CreateStoreAsync(AddStoreRequest addStoreRequest);
        Task<Store> UpdateStoreAsync(Guid id, UpdateStoreRequest updateStoreRequest);
        Task<Store> DeleteStoreAsync(Guid id);
    }
}
