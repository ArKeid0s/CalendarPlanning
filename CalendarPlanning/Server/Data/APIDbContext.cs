using CalendarPlanning.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CalendarPlanning.Server.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
            try
            {
                if (Database.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public required DbSet<Employee> Employees { get; set; }
        public required DbSet<Holiday> Holidays { get; set; }
        public required DbSet<Schedule> Schedules { get; set; }
        public required DbSet<Shift> Shifts { get; set; }
        public required DbSet<Store> Stores { get; set; }
    }
}
