using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.EmployeeRequests;

namespace CalendarPlanning.Server.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(string id);
        Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeRequest createEmployeeRequest);
        Task UpdateEmployeeAsync(string id, UpdateEmployeeRequest updateEmployeeRequest);
        Task DeleteEmployeeAsync(string id);
        Task AddShiftToEmployeeAsync(string id, AddShiftToEmployeeRequest addShiftToEmployeeRequest);
    }
}
