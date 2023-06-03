﻿using CalendarPlanning.Shared.Models.DTO;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeRequest createEmployeeRequest);
        Task<EmployeeDto> UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest updateEmployeeRequest);
        Task<EmployeeDto> DeleteEmployeeAsync(Guid id);
    }
}
