using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Exceptions.IncentiveExceptions;
using CalendarPlanning.Shared.ModelExtensions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CalendarPlanning.Server.Repositories
{
    public class IncentivesRepository : IIncentivesRepository
    {
        private readonly APIDbContext _dbContext;

        public IncentivesRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IncentiveDto> CreateIncentiveAsync(Incentive incentive)
        {
            _dbContext.Incentives.Add(incentive);
            await _dbContext.SaveChangesAsync();

            return incentive.ToDto();
        }

        public async Task<IncentiveDto> DeleteIncentiveAsync(Guid id)
        {
            var incentive = await _dbContext.Incentives
                .FirstOrDefaultAsync(i => i.IncentiveId == id)
                ?? throw new IncentiveNotFoundException(id);

            _dbContext.Incentives.Remove(incentive);
            await _dbContext.SaveChangesAsync();

            return incentive.ToDto();
        }

        public async Task<IncentiveDto> GetIncentiveByIdAsNoTrackingAsync(Guid id)
        {
            var incentive = await _dbContext.Incentives
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.IncentiveId == id)
                ?? throw new IncentiveNotFoundException(id);

            return incentive.ToDto();
        }

        public async Task<IEnumerable<IncentiveDto>> GetIncentivesAsNoTrackingAsync()
        {
            var incentives = await _dbContext.Incentives
                .AsNoTracking()
                .ToListAsync();

            return incentives.Select(i => i.ToDto());
        }

        public async Task<IncentiveDto> UpdateIncentiveAsync(Incentive incentive)
        {
            _dbContext.Incentives.Update(incentive);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IncentiveSaveUpdateException(incentive.IncentiveId, ex.Message);
            }

            return incentive.ToDto();
        }
    }
}