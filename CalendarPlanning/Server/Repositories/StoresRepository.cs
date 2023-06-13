﻿using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Exceptions.StoreExceptions;
using CalendarPlanning.Shared.ModelExtensions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
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

        public async Task<StoreDto> CreateStoreAsync(Store store)
        {
            _dbContext.Stores.Add(store);
            await _dbContext.SaveChangesAsync();

            return store.ToDto();
        }

        public async Task<StoreDto> DeleteStoreAsync(Guid id)
        {
            var store = await _dbContext.Stores
                .FirstOrDefaultAsync(s => s.StoreId == id)
                ?? throw new StoreNotFoundException(id);

            _dbContext.Stores.Remove(store);
            await _dbContext.SaveChangesAsync();

            return store.ToDto();
        }

        public async Task<StoreDto> GetStoreByIdAsync(Guid id)
        {
            var store = await _dbContext.Stores
                .Include(s => s.Employees)
                .FirstOrDefaultAsync(s => s.StoreId == id)
                ?? throw new StoreNotFoundException(id);

            return store.ToDto();
        }

        public async Task<StoreDto> GetStoreByIdAsNoTrackingAsync(Guid id)
        {
            var store = await _dbContext.Stores
                .AsNoTracking()
                .Include(s => s.Employees)
                .FirstOrDefaultAsync(s => s.StoreId == id)
                ?? throw new StoreNotFoundException(id);

            return store.ToDto();
        }

        public async Task<IEnumerable<StoreDto>> GetStoresAsync()
        {
            var stores = await _dbContext.Stores
                .Include(s => s.Employees)
                .ToListAsync();

            return stores.Select(s => s.ToDto());
        }

        public async Task<IEnumerable<StoreDto>> GetStoresAsNoTrackingAsync()
        {
            var stores = await _dbContext.Stores
                .AsNoTracking()
                .Include(s => s.Employees)
                .ToListAsync();

            return stores.Select(s => s.ToDto());
        }

        public async Task<StoreDto> UpdateStoreAsync(Store store)
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

            return store.ToDto();
        }
    }
}
