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

                    // Init default values for test purposes
                    var contextSeed = new ContextSeed();
                    if (!contextSeed.HasData(this))
                    {
                        contextSeed.Seed(this);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public DbSet<Employee> Employees { get; set; } = null!;
        //public DbSet<Holiday> Holidays { get; set; } = null!;
        //public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Shift> Shifts { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;
    }
}
