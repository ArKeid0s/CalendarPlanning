using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Client.Services.Interfaces
{
    public interface IEmployeesService
    {
        List<EmployeeDto>? Employees { get; }
        Task<EmployeeDto?> GetEmployeeByIdAsync(string employeeId);
        Task<List<EmployeeDto>?> GetAllAsync();
        Task<int> GetEmployeesCountAsync();
        Task LoadEmployees();
    }
}
