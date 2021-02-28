using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Orders.Service;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Orders.API
{
    internal static class OrdersModule
    {
        public static IServiceCollection AddOrdersModule(this IServiceCollection services)
        {
            services.AddOrderServices();

            return services;
        }

        public static IApplicationBuilder UseOrdersModule(this IApplicationBuilder app) => app;
    }
}
