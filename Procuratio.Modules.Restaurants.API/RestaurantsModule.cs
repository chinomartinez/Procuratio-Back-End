using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Procuratio.Modules.Restaurants.Service;

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
