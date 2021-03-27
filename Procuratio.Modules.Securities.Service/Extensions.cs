using Microsoft.Extensions.DependencyInjection;

namespace Procuratio.Modules.Securities.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddSecuritiesServices(this IServiceCollection services)
        {
            //services.AddScoped<INTERFAZSERVICIO, CLASESERVICIO>();
            //services.AddSingleton<INTERFAZREPOSITORIO, REPOSITORIO>();

            return services;
        }
    }
}
