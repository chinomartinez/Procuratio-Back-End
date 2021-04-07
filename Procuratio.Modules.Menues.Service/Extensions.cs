using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Menues.DataAccess;

namespace Procuratio.Modules.Menues.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddMenuesServices(this IServiceCollection services)
        {
            //services.AddScoped<INTERFAZSERVICIO, CLASESERVICIO>();
            //services.AddSingleton<INTERFAZREPOSITORIO, REPOSITORIO>();

            services.AddDatabase();

            return services;
        }

        public static IApplicationBuilder AddMenuesApps(this IApplicationBuilder app)
        {
            app.AddDatabase();

            return app;
        }
    }
}
