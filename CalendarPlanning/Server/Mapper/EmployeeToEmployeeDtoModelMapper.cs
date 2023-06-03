using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Mapper
{
    public class EmployeeToEmployeeDtoModelMapper
    {
        public EmployeeDto MapToEmployeeDto(Employee employee) => new()
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            StoreId = employee.StoreId,
            StoreName = employee.Store != null ? employee.Store.Name : string.Empty,
            StoreAddress = employee.Store != null ? employee.Store.Address : string.Empty
        };
    }
}
