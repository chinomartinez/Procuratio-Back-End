using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Restaurants.DataAccess;
using Procuratio.Modules.Restaurants.Service.Repositories;
using Procuratio.Modules.Restaurants.Service.Repositories.Interfaces;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Restaurants.API")]
namespace Procuratio.Modules.Restaurants.Service
{
    internal static class Extensions
    {
        public static IServiceCollection AddRestaurantsServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaruantService, RestaruantService>();
            services.AddScoped<IBranchService, BranchService>();

            services.AddAutoMapper(typeof(Extensions).GetTypeInfo().Assembly);

            services.AddDatabase();

            return services;
        }

        public static IApplicationBuilder AddRestaurantsApps(this IApplicationBuilder app)
        {
            app.AddDatabase();

            return app;
        }
    }
}
