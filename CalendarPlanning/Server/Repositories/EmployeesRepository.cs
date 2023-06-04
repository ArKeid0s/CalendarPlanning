using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Mapper.EmployeeModelMappers;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Exceptions.EmployeeExceptions;
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

            return _mapper.Map(employee);
        }

        public async Task<EmployeeDto> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == id)
                ?? throw new EmployeeNotFoundException(id);

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map(employee);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid employeeId)
        {
            var employee = await _dbContext.Employees
                .Include(e => e.Store)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId)
                ?? throw new EmployeeNotFoundException(employeeId);

            return _mapper.Map(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await _dbContext.Employees
                .Include(e => e.Store)
                .ToListAsync();

            return employees.Select(_mapper.Map);
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

            return _mapper.Map(employee);
        }
    }
}