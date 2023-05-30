using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<Employee> CreateEmployeeAsync(AddEmployeeRequest addEmployeeRequest);
        Task<Employee> UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest updateEmployeeRequest);
        Task<Employee> DeleteEmployeeAsync(Guid id);
    }
}
