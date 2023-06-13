using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Exceptions.EmployeeExceptions;
using CalendarPlanning.Shared.ModelExtensions;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CalendarPlanning.Server.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly APIDbContext _dbContext;

        public EmployeesRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();

            return employee.ToDto();
        }

        public async Task<EmployeeDto> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == id)
                ?? throw new EmployeeNotFoundException(id);

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();

            return employee.ToDto();
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid employeeId)
        {
            var employee = await _dbContext.Employees
                .Include(e => e.Store)
                .Include(e => e.Shifts)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId)
                ?? throw new EmployeeNotFoundException(employeeId);

            return employee.ToDto();
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsNoTrackingAsync(Guid employeeId)
        {
            var employee = await _dbContext.Employees
                .AsNoTracking()
                .Include(e => e.Store)
                .Include(e => e.Shifts)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId)
                ?? throw new EmployeeNotFoundException(employeeId);

            return employee.ToDto();
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await _dbContext.Employees
                .Include(e => e.Store)
                .Include(e => e.Shifts)
                .ToListAsync();

            return employees.Select(e => e.ToDto());
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsNoTrackingAsync()
        {
            var employees = await _dbContext.Employees
                .AsNoTracking()
                .Include(e => e.Store)
                .Include(e => e.Shifts)
                .ToListAsync();

            return employees.Select(e => e.ToDto());
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Update(employee);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new EmployeeSaveUpdateException(employee.EmployeeId, ex.Message);
            }

            return employee.ToDto();
        }
    }
}