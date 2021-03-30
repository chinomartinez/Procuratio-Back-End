using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Securities.DataAccess;

namespace Procuratio.Modules.Securities.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddSecuritiesServices(this IServiceCollection services)
        {
            //services.AddScoped<INTERFAZSERVICIO, CLASESERVICIO>();
            //services.AddSingleton<INTERFAZREPOSITORIO, REPOSITORIO>();

            services.AddDatabase();

            return services;
        }
    }
}
