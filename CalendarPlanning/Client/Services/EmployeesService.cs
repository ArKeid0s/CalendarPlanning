using CalendarPlanning.Client.Services.Interfaces;
using CalendarPlanning.Shared.Models.DTO;
using System.Net.Http.Json;

namespace CalendarPlanning.Client.Services
{
    public class EmployeesService : IEmployeesService
    {
        public List<EmployeeDto>? Employees { get; private set; }

        private readonly HttpClient _http;

        public EmployeesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EmployeeDto>?> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<EmployeeDto>>("api/Employees");
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(string employeeId)
        {
            return await _http.GetFromJsonAsync<EmployeeDto>($"api/Employees/{employeeId}");
        }

        public async Task<int> GetEmployeesCountAsync()
        {
            return await _http.GetFromJsonAsync<int>("api/Employees/Count");
        }

        public async Task LoadEmployees()
        {
            Employees = await GetAllAsync();
        }
    }
}