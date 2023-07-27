using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(string id);
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsNoTrackingAsync();
        Task<EmployeeDto> GetEmployeeByIdAsNoTrackingAsync(string id);
        Task<EmployeeDto> CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(string id);
    }
}
