using CalendarPlanning.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CalendarPlanning.Server.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions options) : base(options)
        {
        }

        public required DbSet<Employee> Employees { get; set; }
        public required DbSet<Holiday> Holidays { get; set; }
        public required DbSet<Schedule> Schedules { get; set; }
        public required DbSet<Shift> Shifts { get; set; }
        public required DbSet<Store> Stores { get; set; }
    }
}
