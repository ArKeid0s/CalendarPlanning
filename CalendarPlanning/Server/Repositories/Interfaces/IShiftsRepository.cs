﻿using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;

namespace CalendarPlanning.Server.Repositories.Interfaces
{
    public interface IShiftsRepository
    {
        Task<IEnumerable<ShiftDto>> GetShiftsAsync();
        Task<ShiftDto> GetShiftByIdAsync(Guid id);
        Task<ShiftDto> CreateShiftAsync(Shift shift);
        Task<ShiftDto> UpdateShiftAsync(Shift shift);
        Task<ShiftDto> DeleteShiftAsync(Guid id);
    }
}
