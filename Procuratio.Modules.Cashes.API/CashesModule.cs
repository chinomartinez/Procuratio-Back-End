using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Cashes.Service;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Cashes.API
{
    public static class CashesModule
    {
        public static IServiceCollection AddCashesModule(this IServiceCollection services)
        {
            services.AddCashesServices();

            return services;
        }

        public static IApplicationBuilder UseCashesModule(this IApplicationBuilder app) => app;
    }
}
