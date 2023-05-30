using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeeRepository;

        public EmployeesService(IEmployeesRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> CreateEmployeeAsync(AddEmployeeRequest addEmployeeRequest)
        {
            addEmployeeRequest.Validate();

            var employee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                FirstName = addEmployeeRequest.FirstName,
                LastName = addEmployeeRequest.LastName,
                StoreId = addEmployeeRequest.StoreId
            };

            return await _employeeRepository.CreateEmployeeAsync(employee);
        }

        public async Task<Employee> DeleteEmployeeAsync(Guid id)
        {
            return await _employeeRepository.DeleteEmployeeAsync(id);
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            updateEmployeeRequest.Validate();

            return await _employeeRepository.UpdateEmployeeAsync(id, updateEmployeeRequest);
        }
    }
}
