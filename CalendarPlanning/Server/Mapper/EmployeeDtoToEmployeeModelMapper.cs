using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Mapper
{
    public class EmployeeDtoToEmployeeModelMapper
    {
        public Employee MapToEmployee(EmployeeDto employeeDto) => new()
        {
            EmployeeId = employeeDto.EmployeeId,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            StoreId = employeeDto.StoreId
        };
    }
}
