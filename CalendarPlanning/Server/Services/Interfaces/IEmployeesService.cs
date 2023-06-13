using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests.EmployeeRequests;

namespace CalendarPlanning.Server.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeRequest createEmployeeRequest);
        Task UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest updateEmployeeRequest);
        Task DeleteEmployeeAsync(Guid id);
        Task AddShiftToEmployeeAsync(Guid id, AddShiftToEmployeeRequest addShiftToEmployeeRequest);
    }
}
