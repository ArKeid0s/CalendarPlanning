using System.Net.Http.Json;
using CalendarPlanning.Client.Services.Interfaces;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Client.Services
{
    public class StoresService : IStoresService
    {
        private readonly HttpClient _http;

        public StoresService(HttpClient http)
        {
            _http = http;
        }

        public Task<List<StoreDto>?> GetAllAsync()
        {
            return _http.GetFromJsonAsync<List<StoreDto>>("api/Stores");
        }
    }
}
