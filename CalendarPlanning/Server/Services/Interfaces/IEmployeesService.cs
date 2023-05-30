using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(Guid id);
        Task<bool> CreateEmployeeAsync(AddEmployeeRequest addEmployeeRequest);
        Task<bool> UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest updateEmployeeRequest);
        Task<bool> DeleteEmployeeAsync(Guid id);
    }
}
