using CalendarPlanning.Server.Authorization;
using CalendarPlanning.Server.Data;
using CalendarPlanning.Server.Middleware;
using CalendarPlanning.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
builder.Services.AddRepositories<APIDbContext>(builder.Configuration).AddServices();
// === DATABASE ===

// === AUTHENTICATION ===
builder.Services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<APIDbContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                    };
                });
builder.Services.AddAuthorizationPolicies();
// === AUTHENTICATION ===

var app = builder.Build();

// === MIDDLEWARE ===
app.UseMiddleware<RequestTimingMiddleware>();
// === MIDDLEWARE ===


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

await app.Services.InitializeDatabaseAsync<APIDbContext>();

await app.Services.AddRoles();
await app.Services.AddAdminUser();

app.UseHttpsRedirection();
app.UseHttpLogging();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
