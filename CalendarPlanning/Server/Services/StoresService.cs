using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Exceptions.StoreExceptions;
using CalendarPlanning.Shared.ModelExtensions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.StoreRequests;

namespace CalendarPlanning.Server.Services
{
    public class StoresService : IStoresService
    {
        private readonly IStoresRepository _storesRepository;
        private readonly IEmployeesRepository _employeesRepository;

        public StoresService(IStoresRepository storesRepository, IEmployeesRepository employeesRepository)
        {
            _storesRepository = storesRepository;
            _employeesRepository = employeesRepository;
        }

        public async Task<StoreDto> CreateStoreAsync(CreateStoreRequest addStoreRequest)
        {
            var employeesDto = await _employeesRepository.GetEmployeesAsync();
            var employees = employeesDto.Select(e => e.ToModel()) as ICollection<Employee>;

            var store = new Store()
            {
                Name = addStoreRequest.Name,
                Address = addStoreRequest.Address,
                Employees = employees
            };

            return await _storesRepository.CreateStoreAsync(store);
        }

        public async Task<StoreDto> DeleteStoreAsync(Guid id)
        {
            return await _storesRepository.DeleteStoreAsync(id);
        }

        public async Task<StoreDto> GetStoreByIdAsync(Guid id)
        {
            return await _storesRepository.GetStoreByIdAsNoTrackingAsync(id);
        }

        public Task<IEnumerable<StoreDto>> GetStoresAsync()
        {
            return _storesRepository.GetStoresAsNoTrackingAsync();
        }

        public async Task<StoreDto> UpdateStoreAsync(Guid id, UpdateStoreRequest updateStoreRequest)
        {
            var storeDto = await _storesRepository.GetStoreByIdAsNoTrackingAsync(id) ?? throw new StoreNotFoundException(id);
            storeDto.Name = updateStoreRequest.Name;
            storeDto.Address = updateStoreRequest.Address;

            var employeesDto = await _employeesRepository.GetEmployeesAsNoTrackingAsync();
            var employees = employeesDto.Where(e => e.StoreId == id).ToList();

            var store = storeDto.ToModel();

            return await _storesRepository.UpdateStoreAsync(store);
        }
    }
}
