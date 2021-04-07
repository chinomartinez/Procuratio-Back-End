using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Menues.Service;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Menues.API
{
    internal static class MenuesModule
    {
        public static IServiceCollection AddMenuesModule(this IServiceCollection services)
        {
            services.AddMenuesServices();

            return services;
        }

        public static IApplicationBuilder UseMenuesModule(this IApplicationBuilder app)
        {
            app.AddMenuesApps();

            return app;
        }
    }
}
