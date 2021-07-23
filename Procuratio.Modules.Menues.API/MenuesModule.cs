using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Menues.Service;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Menues.API
{
    internal static class MenuesModule
    {
        public static IServiceCollection AddMenuModule(this IServiceCollection services)
        {
            services.AddMenuServices();

            return services;
        }

        public static IApplicationBuilder UseMenuModule(this IApplicationBuilder app)
        {
            app.AddMenuApps();

            return app;
        }
    }
}
