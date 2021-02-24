using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Orders.API
{
    internal static class OrdersModule
    {
        public static IServiceCollection AddOrdersModule(this IServiceCollection services) => services;

        public static IApplicationBuilder UseConferenceModule(this IApplicationBuilder app) => app;
    }
}
