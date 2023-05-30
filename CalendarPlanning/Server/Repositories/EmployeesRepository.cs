using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Exceptions;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Models;
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

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> DeleteEmployeeAsync(Guid id)
        {
            var employee = await GetEmployeeByIdAsync(id) ?? throw new EmployeeNotFoundException(id);
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            var employee = await _dbContext.Employees.FindAsync(employeeId) ?? throw new EmployeeNotFoundException(employeeId);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
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
            return employee;
        }
    }
}
