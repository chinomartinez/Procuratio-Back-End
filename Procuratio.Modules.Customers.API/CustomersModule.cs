using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Customers.Service;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Customers.API
{
    internal static class CustomersModule
    {
        public static IServiceCollection AddCustomersModule(this IServiceCollection services)
        {
            services.AddCustomersServices();

            return services;
        }

        public static IApplicationBuilder UseCustomersModule(this IApplicationBuilder app) => app;
    }
}
