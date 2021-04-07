using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Orders.DataAccess;
using Procuratio.Shared.Infrastructure.SQLServer;

namespace Procuratio.Modules.Orders.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services)
        {
            //services.AddScoped<INTERFAZSERVICIO, CLASESERVICIO>();
            //services.AddSingleton<INTERFAZREPOSITORIO, REPOSITORIO>();

            services.AddDatabase();

            return services;
        }

        public static IApplicationBuilder AddOrdersApps(this IApplicationBuilder app)
        {
            app.AddDatabase();

            return app;
        }
    }
}
