using CalendarPlanning.Server.Data;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<bool> CreateEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest employee);
        Task<bool> DeleteEmployeeAsync(Guid id);
        Task<Employee?> GetEmployeeByIdAsync(Guid employeeId);
    }
}
