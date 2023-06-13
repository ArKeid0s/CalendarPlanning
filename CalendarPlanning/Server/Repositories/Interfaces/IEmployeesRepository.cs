using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsNoTrackingAsync();
        Task<EmployeeDto> GetEmployeeByIdAsNoTrackingAsync(Guid id);
        Task<EmployeeDto> CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Guid id);
    }
}
