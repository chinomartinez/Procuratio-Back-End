using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Customers.Service;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Customers.API
{
    internal static class CustomersModule
    {
        public static IServiceCollection AddCustomerModule(this IServiceCollection services)
        {
            services.AddCustomerServices();

            return services;
        }

        public static IApplicationBuilder UseCustomerModule(this IApplicationBuilder app)
        {
            app.AddCustomerApps();

            return app;
        }
    }
}
