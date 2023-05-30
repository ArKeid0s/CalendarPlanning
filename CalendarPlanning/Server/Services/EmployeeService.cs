using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> CreateEmployeeAsync(AddEmployeeRequest addEmployeeRequest)
        {
            var employee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                FirstName = addEmployeeRequest.FirstName,
                LastName = addEmployeeRequest.LastName,
                StoreId = addEmployeeRequest.StoreId
            };

            return await _employeeRepository.CreateEmployeeAsync(employee);
        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            return await _employeeRepository.DeleteEmployeeAsync(id);
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            try
            {
                return await _employeeRepository.GetEmployeesAsync();
            }
            catch (Exception)
            {
                // TODO: Clean logs
                throw;
            }
        }

        public async Task<bool> UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            return await _employeeRepository.UpdateEmployeeAsync(id, updateEmployeeRequest);
        }
    }
}
