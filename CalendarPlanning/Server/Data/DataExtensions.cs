using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Server.Services;

namespace CalendarPlanning.Server.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddRepositories<T>(this IServiceCollection services) where T : DbContext
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost,8001";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "CalendarPlanning";
            var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "sa";
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD") ?? "Adminpwd99!";
            var connectionString = $"Server={dbHost};Database={dbName};User ID={dbUser};Password={dbPassword};TrustServerCertificate=True";

            services.AddDbContext<T>(options => options.UseSqlServer(connectionString))
            // --- Repositories ---
                .AddScoped<IEmployeesRepository, EmployeesRepository>()
                .AddScoped<IHolidaysRepository, HolidaysRepository>()
                .AddScoped<ISchedulesRepository, SchedulesRepository>()
                .AddScoped<IShiftsRepository, ShiftsRepository>()
                .AddScoped<IStoresRepository, StoresRepository>()
                .AddScoped<IIncentivesRepository, IncentivesRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // --- Services ---
            services
                .AddScoped<IEmployeesService, EmployeesService>()
                .AddScoped<IHolidaysService, HolidaysService>()
                .AddScoped<ISchedulesService, SchedulesService>()
                .AddScoped<IShiftsService, ShiftsService>()
                .AddScoped<IStoresService, StoresService>()
                .AddScoped<IIncentivesService, IncentivesService>();

            return services;
        }

        public static async Task InitializeDatabaseAsync<T>(this IServiceProvider serviceProvider) where T : DbContext
        {
            using var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<T>();
            await context.Database.MigrateAsync();

            // Init default values for test purposes
            var contextSeed = new ContextSeed();
            if (context is APIDbContext apiContext && !contextSeed.HasData(apiContext))
            {
                contextSeed.Seed(apiContext);
            }
        }
    }
}
