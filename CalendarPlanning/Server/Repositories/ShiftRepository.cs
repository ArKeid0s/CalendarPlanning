using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;

namespace CalendarPlanning.Server.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        public Task<bool> CreateShiftAsync(Shift shift)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteShiftAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Shift?> GetShiftByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shift>> GetShiftsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateShiftAsync(Guid id, UpdateShiftRequest updateShiftRequest)
        {
            throw new NotImplementedException();
        }
    }
}
