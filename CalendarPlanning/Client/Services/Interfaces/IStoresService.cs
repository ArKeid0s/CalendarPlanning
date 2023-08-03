using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Client.Services.Interfaces
{
    public interface IStoresService
    {
        Task<List<StoreDto>?> GetAllAsync();
    }
}
