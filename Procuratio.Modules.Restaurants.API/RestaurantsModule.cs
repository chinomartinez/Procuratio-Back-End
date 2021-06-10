using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Restaurants.Service;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Restaurants.API
{
    internal static class RestaurantsModule
    {
        public static IServiceCollection AddRestaurantsModule(this IServiceCollection services)
        {
            services.AddRestaurantsServices();

            return services;
        }

        public static IApplicationBuilder UseRestaurantsModule(this IApplicationBuilder app)
        {
            app.AddRestaurantsApps();

            return app;
        }
    }
}
