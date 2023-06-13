using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Exceptions.ShiftExceptions;
using CalendarPlanning.Shared.Exceptions.StoreExceptions;
using CalendarPlanning.Shared.ModelExtensions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.EmployeeRequests;

namespace CalendarPlanning.Server.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IStoresRepository _storesRepository;

        public EmployeesService(IEmployeesRepository employeesRepository, IStoresRepository storesRepository)
        {
            _employeesRepository = employeesRepository;
            _storesRepository = storesRepository;
        }

        public async Task AddShiftToEmployeeAsync(Guid id, AddShiftToEmployeeRequest addShiftToEmployeeRequest)
        {
            var employeeDto = await _employeesRepository.GetEmployeeByIdAsNoTrackingAsync(id);
            
            var existingShift = employeeDto.Shifts?.FirstOrDefault(s => s.ShiftType == addShiftToEmployeeRequest.ShiftType);

            var employee = employeeDto.ToModel();

            if (existingShift != null)
            {
                var shiftToUpdate = (employee.Shifts?.FirstOrDefault(s => s.ShiftId == existingShift.ShiftId)) ?? throw new ShiftNotFoundException(existingShift.ShiftId);
                shiftToUpdate.HourStart = addShiftToEmployeeRequest.HourStart;
                shiftToUpdate.HourEnd = addShiftToEmployeeRequest.HourEnd;
                // TODO: tracking problem, will not be saved
            }
            else
            {
                var newShift = new Shift
                {
                    ShiftType = addShiftToEmployeeRequest.ShiftType,
                    HourStart = addShiftToEmployeeRequest.HourStart,
                    HourEnd = addShiftToEmployeeRequest.HourEnd
                };

                employee.Shifts ??= new List<Shift>();
                employee.Shifts.Add(newShift);

            }

            await _employeesRepository.UpdateEmployeeAsync(employee);
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeRequest createEmployeeRequest)
        {
            var stores = await _storesRepository.GetStoresAsNoTrackingAsync();
            var store = stores.FirstOrDefault(s => s.Name == createEmployeeRequest.StoreName) ?? throw new StoreNotFoundException(createEmployeeRequest.StoreName);

            var employee = new Employee()
            {
                FirstName = createEmployeeRequest.FirstName,
                LastName = createEmployeeRequest.LastName,
                StoreId = store.StoreId
            };

            return await _employeesRepository.CreateEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            await _employeesRepository.DeleteEmployeeAsync(id);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeesRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            return await _employeesRepository.GetEmployeesAsync();
        }

        public async Task UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var stores = await _storesRepository.GetStoresAsNoTrackingAsync();
            var store = stores.FirstOrDefault(s => s.Name == updateEmployeeRequest.StoreName) ?? throw new StoreNotFoundException(updateEmployeeRequest.StoreName);

            var employeeDto = await _employeesRepository.GetEmployeeByIdAsNoTrackingAsync(id);
            employeeDto.FirstName = updateEmployeeRequest.FirstName;
            employeeDto.LastName = updateEmployeeRequest.LastName;
            employeeDto.StoreId = store.StoreId;

            var employee = employeeDto.ToModel();

            await _employeesRepository.UpdateEmployeeAsync(employee);
        }
    }
}
