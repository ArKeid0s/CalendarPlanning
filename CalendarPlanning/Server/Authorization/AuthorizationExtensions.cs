namespace CalendarPlanning.Server.Authorization
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                // Read Access
                options.AddPolicy(Policies.ReadAccess, builder => builder
                    .RequireClaim("scope", "Calendar:Read"));

                // Write Access
                options.AddPolicy(Policies.WriteAccess, builder => builder
                    .RequireClaim("scope", "Calendar:Write")
                    .RequireRole("Admin"));
            });

            return services;
        }
    }
}
