using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Securities.Service;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Securities.API
{
    internal static class SecuritiesModule
    {
        public static IServiceCollection AddSecurityModule(this IServiceCollection services)
        {
            services.AddSecurityServices();

            return services;
        }

        public static IApplicationBuilder UseSecurityModule(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.AddSecurityApps();

            return app;
        }
    }
}
