using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Shared.ModelExtensions
{
    public static class EmployeeExtensions
    {
        public static EmployeeDto ToDto(this Employee employee) => new()
        {
            EmployeeId = employee.EmployeeId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            StoreId = employee.StoreId,
            StoreName = employee.Store != null ? employee.Store.Name : string.Empty,
            StoreAddress = employee.Store != null ? employee.Store.Address : string.Empty,
            //Shifts = employee.Shifts?.Select(s => s.ToDto()).ToList()
        };

        public static Employee ToModel(this EmployeeDto employeeDto) => new()
        {
            EmployeeId = employeeDto.EmployeeId,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            StoreId = employeeDto.StoreId,
            //Shifts = employeeDto.Shifts?.Select(s => s.ToModel()).ToList()
        };
    }
}