using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Mapper.ShiftModelMappers;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Exceptions.ShiftExceptions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CalendarPlanning.Server.Repositories
{
    public class ShiftsRepository : IShiftsRepository
    {
        private readonly APIDbContext _dbContext;

        private readonly ShiftToShiftDtoModelMapper _mapper = new();

        public ShiftsRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShiftDto> CreateShiftAsync(Shift shift)
        {
            _dbContext.Shifts.Add(shift);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map(shift);
        }

        public async Task<ShiftDto> DeleteShiftAsync(Guid id)
        {
            var shift = await _dbContext.Shifts
                .FirstOrDefaultAsync(s => s.ShiftId == id)
                ?? throw new ShiftNotFoundException(id);

            _dbContext.Shifts.Remove(shift);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map(shift);
        }

        public async Task<ShiftDto> GetShiftByIdAsync(Guid id)
        {
            var shift = await _dbContext.Shifts
                .FirstOrDefaultAsync(s => s.ShiftId == id)
                ?? throw new ShiftNotFoundException(id);

            return _mapper.Map(shift);
        }

        public async Task<IEnumerable<ShiftDto>> GetShiftsAsync()
        {
            var shifts = await _dbContext.Shifts
                .ToListAsync();

            return shifts.Select(_mapper.Map);
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

            return _mapper.Map(shift);
        }
    }
}