using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Restaurant.Service.Service;
using Procuratio.Modules.Restaurant.Service.Service.Interfaces;
using Procuratio.Modules.Restaurants.DataAccess;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Restaurant.API")]
namespace Procuratio.Modules.Restaurants.Service
{
    internal static class Extensions
    {
        public static IServiceCollection AddRestaurantServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IBranchService, BranchService>();

            services.AddAutoMapper(typeof(Extensions).GetTypeInfo().Assembly);

            services.AddDatabase();

            return services;
        }

        public static IApplicationBuilder AddRestaurantApps(this IApplicationBuilder app)
        {
            app.AddDatabase();

            return app;
        }
    }
}
