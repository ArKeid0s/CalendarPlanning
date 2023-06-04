using CalendarPlanning.Server.Mapper.Interfaces;
using CalendarPlanning.Server.Mapper.ShiftModelMappers;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Mapper.EmployeeModelMappers
{
    public class EmployeeToEmployeeDtoModelMapper : IModelMapper<EmployeeDto, Employee>
    {
        private readonly ShiftToShiftDtoModelMapper _mapper = new();

        public EmployeeDto Map(Employee employee) => new()
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            StoreId = employee.StoreId,
            StoreName = employee.Store != null ? employee.Store.Name : string.Empty,
            StoreAddress = employee.Store != null ? employee.Store.Address : string.Empty,
            Shifts = employee.Shifts?.Select(_mapper.Map).ToList()
        };
    }
}
