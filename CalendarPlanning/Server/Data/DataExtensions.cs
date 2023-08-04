using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Repositories;
using Microsoft.EntityFrameworkCore;
using CalendarPlanning.Server.Services.Interfaces;
using CalendarPlanning.Server.Services;
using Microsoft.AspNetCore.Identity;
using CalendarPlanning.Shared.Models;
using System.Diagnostics;

namespace CalendarPlanning.Server.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddRepositories<T>(this IServiceCollection services) where T : DbContext
        {
            var connectionString = Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_AZURE_POSTGRESQL_CONNECTIONSTRING");

            services.AddDbContext<T>(options => options.UseNpgsql(connectionString))
            // --- Repositories ---
                .AddScoped<IEmployeesRepository, EmployeesRepository>()
                .AddScoped<IHolidaysRepository, HolidaysRepository>()
                .AddScoped<ISchedulesRepository, SchedulesRepository>()
                //.AddScoped<IShiftsRepository, ShiftsRepository>()
                .AddScoped<IStoresRepository, StoresRepository>()
                .AddScoped<IIncentiveValuesRepository, IncentiveValuesRepository>()
                .AddScoped<IIncentivesRepository, IncentivesRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // --- Services ---
            services
                .AddHttpContextAccessor()
                .AddScoped<IEmployeesService, EmployeesService>()
                .AddScoped<IHolidaysService, HolidaysService>()
                .AddScoped<ISchedulesService, SchedulesService>()
                //.AddScoped<IShiftsService, ShiftsService>()
                .AddScoped<IStoresService, StoresService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IIncentiveValuesService, IncentiveValuesService>()
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
            var dbContext = scope.ServiceProvider.GetRequiredService<APIDbContext>();

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
                dbContext.Employees.Add(new Employee
                {
                    EmployeeId = adminUser.Id,
                    FirstName = "Admin",
                    LastName = "Admin",
                    StoreId = dbContext.Stores.FirstOrDefault()!.StoreId
                });
                dbContext.SaveChanges();
            }
        }
    }
}
