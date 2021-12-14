using Microsoft.Extensions.DependencyInjection;
using Procuratio.Shared.Abstractions.Tenant;

namespace Procuratio.Shared.Infrastructure.Tenant
{
    internal static class Extensions
    {
        public static IServiceCollection AddTenant(this IServiceCollection services)
        {
            services.AddScoped<ITenantService, TenantService>();

            return services;
        }
    }
}
