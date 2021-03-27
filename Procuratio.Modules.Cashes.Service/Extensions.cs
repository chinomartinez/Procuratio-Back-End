using Microsoft.Extensions.DependencyInjection;

namespace Procuratio.Modules.Cashes.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddCashesServices(this IServiceCollection services)
        {
            //services.AddScoped<INTERFAZSERVICIO, CLASESERVICIO>();
            //services.AddSingleton<INTERFAZREPOSITORIO, REPOSITORIO>();

            return services;
        }
    }
}
