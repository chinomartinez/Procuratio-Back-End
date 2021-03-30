using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Cashes.Service;
using System.Runtime.CompilerServices;

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
