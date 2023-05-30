using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Shared.Models;
using CalendarPlanning.Shared.Models.Requests;
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

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            try
            {
                await _dbContext.Employees.AddAsync(employee);
                var saveResult = await _dbContext.SaveChangesAsync();

                return saveResult > 0; // renvoie true si au moins une entité a été affectée (sauvegardée), false sinon
            }
            catch (Exception)
            {
                // TODO: clean log
                return false;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var employee = await GetEmployeeByIdAsync(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                var saveResult = await _dbContext.SaveChangesAsync();

                return saveResult > 0;
            }

            return false;
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid employeeId)
        {
            return await _dbContext.Employees.FindAsync(employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<bool> UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var employee = await GetEmployeeByIdAsync(id);

            if (employee != null)
            {
                employee.FirstName = updateEmployeeRequest.FirstName;
                employee.LastName = updateEmployeeRequest.LastName;
                employee.StoreId = updateEmployeeRequest.StoreId;

                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false; //TODO: throw custom exception
        }
    }
}
