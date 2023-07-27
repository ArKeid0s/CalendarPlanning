using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Server.Services;
using Microsoft.AspNetCore.Identity;
using CalendarPlanning.Shared.Models;

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

            services.AddDbContext<T>(options => options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
            }))
            // --- Repositories ---
                .AddScoped<IEmployeesRepository, EmployeesRepository>()
                .AddScoped<IHolidaysRepository, HolidaysRepository>()
                .AddScoped<ISchedulesRepository, SchedulesRepository>()
                //.AddScoped<IShiftsRepository, ShiftsRepository>()
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
                //.AddScoped<IShiftsService, ShiftsService>()
                .AddScoped<IStoresService, StoresService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
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

        public static async Task AddRoles(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Admin", "Manager", "Employee" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public static async Task AddAdminUser(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var adminUser = new ApplicationUser
            {
                UserName = Environment.GetEnvironmentVariable("ADMIN_EMAIL") ?? throw new ArgumentNullException("Environment variable ADMIN_EMAIL is not set."),
                Email = Environment.GetEnvironmentVariable("ADMIN_EMAIL") ?? throw new ArgumentNullException("Environment variable ADMIN_EMAIL is not set.")
            };
            string adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD") ?? throw new ArgumentNullException("Environment variable ADMIN_PASSWORD is not set.");

            var user = await userManager.FindByEmailAsync(adminUser.Email);

            if (user == null)
            {
                var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
                if (createAdminUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
