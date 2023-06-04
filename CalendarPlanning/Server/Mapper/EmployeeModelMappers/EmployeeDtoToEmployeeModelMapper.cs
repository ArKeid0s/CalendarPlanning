using CalendarPlanning.Server.Mapper.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Mapper.EmployeeModelMappers
{
    public class EmployeeDtoToEmployeeModelMapper : IModelMapper<Employee, EmployeeDto>
    {
        public Employee Map(EmployeeDto employeeDto) => new()
        {
            EmployeeId = employeeDto.EmployeeId,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            StoreId = employeeDto.StoreId
        };
    }
}
