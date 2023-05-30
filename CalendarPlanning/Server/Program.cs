using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Repositories;
using CalendarPlanning.Server.Repositories.Interfaces;
using CalendarPlanning.Server.Services;
using CalendarPlanning.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CalendarPlanning", Version = "v1" });
});



// === DATABASE ===
var dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "CalendarPlanning";
var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "sa";
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD") ?? "Password123";
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID={dbUser};Password={dbPassword};TrustServerCertificate=True";
builder.Services.AddDbContext<APIDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// === DATABASE ===



// === INJECTION ===

// --- Repositories ---
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<IHolidaysRepository, HolidaysRepository>();
builder.Services.AddScoped<ISchedulesRepository, SchedulesRepository>();
builder.Services.AddScoped<IShiftsRepository, ShiftsRepository>();
builder.Services.AddScoped<IStoresRepository, StoresRepository>();

// --- Services ---
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<IHolidaysService, HolidaysService>();
builder.Services.AddScoped<ISchedulesService, SchedulesService>();
builder.Services.AddScoped<IShiftsService, ShiftsService>();
builder.Services.AddScoped<IStoresService, StoresService>();

// === INJECTION ===



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
         c.SwaggerEndpoint("/swagger/v1/swagger.json", "CalendarPlanning v1"));
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
