using CalendarPlanning.Client.Services.Interfaces;
using CalendarPlanning.Shared.Models.DTO;
using System.Net.Http.Json;

namespace CalendarPlanning.Client.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly HttpClient _http;

        public EmployeesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EmployeeDto>?> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<EmployeeDto>>("api/Employees");
        }
    }
}
