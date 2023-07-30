using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Client.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<List<EmployeeDto>?> GetAllAsync();
    }
}
