using Microsoft.Extensions.DependencyInjection;
using Procuratio.Shared.Abstractions.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
