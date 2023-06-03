using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Server.Mapper;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CalendarPlanning.Server.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly APIDbContext _dbContext;

        private readonly EmployeeToEmployeeDtoModelMapper _mapper = new();

        public EmployeesRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();

            return _mapper.MapToEmployeeDto(employee);
        }

        public async Task<EmployeeDto> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id) ?? throw new EmployeeNotFoundException(id);
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();

            return _mapper.MapToEmployeeDto(employee);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid employeeId)
        {
            var employee = await _dbContext.Employees
                .Include(e => e.Store)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId)
                ?? throw new EmployeeNotFoundException(employeeId);

            return _mapper.MapToEmployeeDto(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await _dbContext.Employees.Include(e => e.Store).ToListAsync();

            return employees.Select(_mapper.MapToEmployeeDto);
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

            return _mapper.MapToEmployeeDto(employee);
        }
    }
}
