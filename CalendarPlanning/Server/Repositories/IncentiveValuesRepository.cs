using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Exceptions.IncentiveValueExceptions;
using CalendarPlanning.Shared.ModelExtensions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CalendarPlanning.Server.Repositories
{
    public class IncentiveValuesRepository : IIncentiveValuesRepository
    {
        private readonly APIDbContext _dbContext;

        public IncentiveValuesRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IncentiveValueDto> GetIncentiveValueByIdAsNoTrackingAsync(int id)
        {
            var incentiveValue = await _dbContext.IncentiveValues
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new IncentiveValueNotFoundException(id);

            return incentiveValue.ToDto();
        }

        public async Task<IEnumerable<IncentiveValueDto>> GetIncentiveValuesAsNoTrackingAsync()
        {
            var incentiveValues = await _dbContext.IncentiveValues
                .AsNoTracking()
                .ToListAsync();

            return incentiveValues.Select(i => i.ToDto());
        }

        public async Task UpdateIncentiveValueAsNoTrackingAsync(int id, IncentiveValue incentiveValue)
        {
            _dbContext.IncentiveValues.Update(incentiveValue);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IncentiveValueSaveUpdateException(incentiveValue.Id, ex.Message);
            }
        }
    }
}
