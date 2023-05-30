using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<Employee> CreateEmployeeAsync(AddEmployeeRequest addEmployeeRequest)
        {
            addEmployeeRequest.Validate();

            var employee = new Employee()
            {
                FirstName = addEmployeeRequest.FirstName,
                LastName = addEmployeeRequest.LastName,
                StoreId = addEmployeeRequest.StoreId
            };

            return await _employeesRepository.CreateEmployeeAsync(employee);
        }

        public async Task<Employee> DeleteEmployeeAsync(Guid id)
        {
            return await _employeesRepository.DeleteEmployeeAsync(id);
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeesRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeesRepository.GetEmployeesAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            updateEmployeeRequest.Validate();

            var employee = await _employeesRepository.GetEmployeeByIdAsync(id) ?? throw new EmployeeNotFoundException(id);
            employee.FirstName = updateEmployeeRequest.FirstName;
            employee.LastName = updateEmployeeRequest.LastName;
            employee.StoreId = updateEmployeeRequest.StoreId;

            return await _employeesRepository.UpdateEmployeeAsync(employee);
        }
    }
}
