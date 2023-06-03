using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeDto> CreateEmployeeAsync(Employee employee);
        Task<EmployeeDto> UpdateEmployeeAsync(Employee employee);
        Task<EmployeeDto> DeleteEmployeeAsync(Guid id);
    }
}
