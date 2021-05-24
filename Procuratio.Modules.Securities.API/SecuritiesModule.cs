using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Securities.Service;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Securities.API
{
    internal static class SecuritiesModule
    {
        public static IServiceCollection AddSecuritiesModule(this IServiceCollection services)
        {
            services.AddSecuritiesServices();

            return services;
        }

        public static IApplicationBuilder UseSecuritiesModule(this IApplicationBuilder app) 
        {
            app.UseAuthentication();
            app.AddSecuritiesApps();

            return app;
        }
    }
}
