using CalendarPlanning.Server.Mapper.EmployeeModelMappers;
using CalendarPlanning.Server.Mapper.StoreModelMappers;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.StoreRequests;

namespace CalendarPlanning.Server.Services
{
    public class StoresService : IStoresService
    {
        private readonly IStoresRepository _storesRepository;
        private readonly IEmployeesRepository _employeesRepository;

        private readonly EmployeeDtoToEmployeeModelMapper _employeeMapper = new();
        private readonly StoreDtoToStoreModelMapper _storeMapper = new();

        public StoresService(IStoresRepository storesRepository, IEmployeesRepository employeesRepository)
        {
            _storesRepository = storesRepository;
            _employeesRepository = employeesRepository;
        }

        public async Task<StoreDto> CreateStoreAsync(CreateStoreRequest addStoreRequest)
        {
            addStoreRequest.Validate();

            var employeesDto = await _employeesRepository.GetEmployeesAsync();
            var employees = employeesDto.Select(_employeeMapper.Map) as ICollection<Employee>;

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
            return await _storesRepository.GetStoreByIdAsync(id);
        }

        public Task<IEnumerable<StoreDto>> GetStoresAsync()
        {
            return _storesRepository.GetStoresAsync();
        }

        public async Task<StoreDto> UpdateStoreAsync(Guid id, UpdateStoreRequest updateStoreRequest)
        {
            updateStoreRequest.Validate();

            var storeDto = await _storesRepository.GetStoreByIdAsync(id) ?? throw new StoreNotFoundException(id);
            storeDto.Name = updateStoreRequest.Name;
            storeDto.Address = updateStoreRequest.Address;

            var employeesDto = await _employeesRepository.GetEmployeesAsync();
            var employees = employeesDto.Where(e => e.StoreId == id).ToList();

            var store = _storeMapper.Map(storeDto);

            return await _storesRepository.UpdateStoreAsync(store);
        }
    }
}
