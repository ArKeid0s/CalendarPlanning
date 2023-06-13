using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Exceptions.ShiftExceptions;
using CalendarPlanning.Shared.ModelExtensions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CalendarPlanning.Server.Repositories
{
    public class ShiftsRepository : IShiftsRepository
    {
        private readonly APIDbContext _dbContext;

        public ShiftsRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShiftDto> CreateShiftAsync(Shift shift)
        {
            _dbContext.Shifts.Add(shift);
            await _dbContext.SaveChangesAsync();

            return shift.ToDto();
        }

        public async Task<ShiftDto> DeleteShiftAsync(Guid id)
        {
            var shift = await _dbContext.Shifts
                .FirstOrDefaultAsync(s => s.ShiftId == id)
                ?? throw new ShiftNotFoundException(id);

            _dbContext.Shifts.Remove(shift);
            await _dbContext.SaveChangesAsync();

            return shift.ToDto();
        }

        public async Task<ShiftDto> GetShiftByIdAsNoTrackingAsync(Guid id)
        {
            var shift = await _dbContext.Shifts
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.ShiftId == id)
                ?? throw new ShiftNotFoundException(id);

            return shift.ToDto();
        }

        public async Task<ShiftDto> GetShiftByIdAsync(Guid id)
        {
            var shift = await _dbContext.Shifts
                .FirstOrDefaultAsync(s => s.ShiftId == id)
                ?? throw new ShiftNotFoundException(id);

            return shift.ToDto();
        }

        public async Task<IEnumerable<ShiftDto>> GetShiftsAsNoTrackingAsync()
        {
            var shifts = await _dbContext.Shifts
                .AsNoTracking()
                .ToListAsync();

            return shifts.Select(s => s.ToDto());
        }

        public async Task<IEnumerable<ShiftDto>> GetShiftsAsync()
        {
            var shifts = await _dbContext.Shifts
                .ToListAsync();

            return shifts.Select(s => s.ToDto());
        }

        public async Task<ShiftDto> UpdateShiftAsync(Shift shift)
        {
            _dbContext.Shifts.Update(shift);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new ShiftSaveUpdateException(shift.ShiftId, ex.Message);
            }

            return shift.ToDto();
        }
    }
}