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
        private readonly IHttpContextAccessor _http;

        public IncentivesRepository(APIDbContext dbContext, IHttpContextAccessor http)
        {
            _dbContext = dbContext;
            _http = http;
        }

        public async Task<IncentiveDto> CreateIncentiveAsync(Incentive incentive)
        {
            _dbContext.Incentives.Add(incentive);
            await _dbContext.SaveChangesAsync();

            return incentive.ToDto();
        }

        public async Task DeleteIncentiveAsync(Guid id)
        {
            var result = await _dbContext.Incentives.Where(i => i.IncentiveId == id)
                .ExecuteDeleteAsync();

            if (result == 0) throw new IncentiveNotFoundException(id);
        }

        public async Task DeleteIncentiveOfUserByIdAsync(string userId, Guid id)
        {
            IQueryable<Incentive> query;

            if (_http.HttpContext!.User.IsInRole("Admin"))
            {
                query = _dbContext.Incentives.Where(i => i.IncentiveId == id);
            }
            else
            {
                query = _dbContext.Incentives.Where(i => i.IncentiveId == id && i.EmployeeId == userId);
            }

            int result = await query.ExecuteDeleteAsync();

            if (result == 0) throw new IncentiveNotFoundException(id);
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

        public async Task UpdateIncentiveAsync(Incentive incentive)
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
        }
    }
}