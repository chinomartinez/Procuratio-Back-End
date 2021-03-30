using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Cashes.DataAccess;

namespace Procuratio.Modules.Cashes.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddCashesServices(this IServiceCollection services)
        {
            //services.AddScoped<INTERFAZSERVICIO, CLASESERVICIO>();
            //services.AddSingleton<INTERFAZREPOSITORIO, REPOSITORIO>();

            services.AddDatabase();

            return services;
        }
    }
}
