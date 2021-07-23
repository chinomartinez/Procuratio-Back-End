using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Restaurants.Service;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Modules.Restaurants.API
{
    internal static class RestaurantsModule
    {
        public static IServiceCollection AddRestaurantModule(this IServiceCollection services)
        {
            services.AddRestaurantServices();

            return services;
        }

        public static IApplicationBuilder UseRestaurantModule(this IApplicationBuilder app)
        {
            app.AddRestaurantApps();

            return app;
        }
    }
}
