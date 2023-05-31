using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace CalendarPlanning.Server.Repositories
{
    public class StoresRepository : IStoresRepository
    {
        private readonly APIDbContext _dbContext;

        public StoresRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Store> CreateStoreAsync(Store store)
        {
            _dbContext.Stores.Add(store);
            await _dbContext.SaveChangesAsync();

            return store;
        }

        public async Task<Store> DeleteStoreAsync(Guid id)
        {
            var store = await GetStoreByIdAsync(id) ?? throw new StoreNotFoundException(id);
            _dbContext.Stores.Remove(store);
            await _dbContext.SaveChangesAsync();

            return store;
        }

        public async Task<Store> GetStoreByIdAsync(Guid id)
        {
            var store = await _dbContext.Stores.FindAsync(id) ?? throw new StoreNotFoundException(id);

            return store;
        }

        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            return await _dbContext.Stores.ToListAsync();
        }

        public async Task<Store> UpdateStoreAsync(Store store)
        {
            _dbContext.Stores.Update(store);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new StoreSaveUpdateException(store.StoreId, ex.Message);
            }

            return store;
        }
    }
}
