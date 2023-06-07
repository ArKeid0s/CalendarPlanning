using CalendarPlanning.Server.Mapper.Interfaces;
using CalendarPlanning.Server.Mapper.ShiftModelMappers;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Mapper.EmployeeModelMappers
{
    public class EmployeeDtoToEmployeeModelMapper : IModelMapper<Employee, EmployeeDto>
    {
        private readonly ShiftDtoToShiftModelMapper _mapper = new();

        public Employee Map(EmployeeDto employeeDto) => new()
        {
            EmployeeId = employeeDto.EmployeeId,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            StoreId = employeeDto.StoreId,
            Shifts = employeeDto.Shifts?.Select(_mapper.Map).ToList()
        };
    }
}
