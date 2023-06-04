using CalendarPlanning.Server.Mapper.EmployeeModelMappers;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Exceptions.StoreExceptions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.EmployeeRequests;

namespace CalendarPlanning.Server.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IStoresRepository _storesRepository;

        private readonly EmployeeDtoToEmployeeModelMapper _mapper = new();

        public EmployeesService(IEmployeesRepository employeesRepository, IStoresRepository storesRepository)
        {
            _employeesRepository = employeesRepository;
            _storesRepository = storesRepository;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeRequest createEmployeeRequest)
        {
            createEmployeeRequest.Validate();

            var stores = await _storesRepository.GetStoresAsync();
            var store = stores.FirstOrDefault(s => s.Name == createEmployeeRequest.StoreName) ?? throw new StoreNotFoundException(createEmployeeRequest.StoreName);

            var employee = new Employee()
            {
                FirstName = createEmployeeRequest.FirstName,
                LastName = createEmployeeRequest.LastName,
                StoreId = store.StoreId
            };

            return await _employeesRepository.CreateEmployeeAsync(employee);
        }

        public async Task<EmployeeDto> DeleteEmployeeAsync(Guid id)
        {
            return await _employeesRepository.DeleteEmployeeAsync(id);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeesRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            return await _employeesRepository.GetEmployeesAsync();
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            updateEmployeeRequest.Validate();

            var stores = await _storesRepository.GetStoresAsync();
            var store = stores.FirstOrDefault(s => s.Name == updateEmployeeRequest.StoreName) ?? throw new StoreNotFoundException(updateEmployeeRequest.StoreName);

            var employeeDto = await _employeesRepository.GetEmployeeByIdAsync(id);
            var employee = _mapper.Map(employeeDto);

            return await _employeesRepository.UpdateEmployeeAsync(employee);
        }
    }
}
