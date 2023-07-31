using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace CalendarPlanning.Server.Authorization
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorizationBuilder()
                .AddPolicy(Policies.ReadAccess, builder => builder
                            .RequireAuthenticatedUser()
                            .RequireClaim("scope", "Calendar:Read"))

                .AddPolicy(Policies.WriteAccess, builder => builder
                            .RequireAuthenticatedUser()
                            .RequireClaim("scope", "Calendar:Write")
                            .RequireRole("Admin"))

                .AddPolicy(Policies.ConcernedUser, builder => builder
                            .RequireAuthenticatedUser()
                            .RequireAssertion(context =>
                            {
                                var user = context.User;
                                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                                var routeId = (context.Resource as DefaultHttpContext)?.HttpContext.Request.RouteValues["userId"]?.ToString();

                                if (userId != null && routeId != null)
                                {
                                    // Allow if the user is accessing their own data or is an admin.
                                    return userId == routeId || user.IsInRole("Admin");
                                }

                                // Deny by default.
                                return false;
                            }));

            return services;
        }
    }
}
