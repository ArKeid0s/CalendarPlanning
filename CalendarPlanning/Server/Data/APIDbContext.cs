using CalendarPlanning.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalendarPlanning.Server.Data
{
    public class APIDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
        //public DbSet<Holiday> Holidays { get; set; } = null!;
        //public DbSet<Schedule> Schedules { get; set; } = null!;
        //public DbSet<Shift> Shifts { get; set; } = null!;
        public DbSet<Store> Stores => Set<Store>();
        public DbSet<Incentive> Incentives => Set<Incentive>();
        public DbSet<IncentiveValue> IncentiveValues => Set<IncentiveValue>();
    }
}
