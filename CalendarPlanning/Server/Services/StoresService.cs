using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Services
{
    public class StoresService : IStoresService
    {
        private readonly IStoresRepository _storesRepository;

        public StoresService(IStoresRepository storesRepository)
        {
            _storesRepository = storesRepository;
        }

        public async Task<Store> CreateStoreAsync(AddStoreRequest addStoreRequest)
        {
            addStoreRequest.Validate();

            var store = new Store()
            {
                Name = addStoreRequest.Name,
                Address = addStoreRequest.Address
            };

            return await _storesRepository.CreateStoreAsync(store);
        }

        public async Task<Store> DeleteStoreAsync(Guid id)
        {
            return await _storesRepository.DeleteStoreAsync(id);
        }

        public async Task<Store> GetStoreByIdAsync(Guid id)
        {
            return await _storesRepository.GetStoreByIdAsync(id);
        }

        public Task<IEnumerable<Store>> GetStoresAsync()
        {
            return _storesRepository.GetStoresAsync();
        }

        public async Task<Store> UpdateStoreAsync(Guid id, UpdateStoreRequest updateStoreRequest)
        {
            updateStoreRequest.Validate();

            var store = await _storesRepository.GetStoreByIdAsync(id) ?? throw new StoreNotFoundException(id);
            store.Name = updateStoreRequest.Name;
            store.Address = updateStoreRequest.Address;

            return await _storesRepository.UpdateStoreAsync(store);
        }
    }
}
