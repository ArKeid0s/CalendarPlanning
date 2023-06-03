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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Shift>()
        //        .HasOne(s => s.Employee)
        //        .WithMany(e => e.Shifts)
        //        .OnDelete(DeleteBehavior.Restrict); // Prevents cascading deletes from Employee to Shift but implies that the shift deletion has to be done manually

        //    modelBuilder.Entity<Shift>()
        //        .HasOne(s => s.Schedule)
        //        .WithMany(sc => sc.Shifts)
        //        .OnDelete(DeleteBehavior.Restrict); // Prevents cascading deletes from Schedule to Shift but implies that the shift deletion has to be done manually

        //    modelBuilder.Entity<Employee>()
        //        .HasOne(e => e.Store)
        //        .WithMany(s => s.Employees)
        //        .OnDelete(DeleteBehavior.Restrict);

        //}


        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Holiday> Holidays { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Shift> Shifts { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;
    }
}
