using CalendarPlanning.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CalendarPlanning.Server.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }


        public DbSet<Employee> Employees => Set<Employee>();
        //public DbSet<Holiday> Holidays { get; set; } = null!;
        //public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Shift> Shifts => Set<Shift>();
        public DbSet<Store> Stores => Set<Store>();
        public DbSet<Incentive> Incentives => Set<Incentive>();
    }
}
