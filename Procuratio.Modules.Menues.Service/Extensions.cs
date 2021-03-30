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
    }
}
