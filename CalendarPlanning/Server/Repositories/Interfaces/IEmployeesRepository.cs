using CalendarPlanning.Shared.Models;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(Guid id);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<Employee> DeleteEmployeeAsync(Guid id);
    }
}
