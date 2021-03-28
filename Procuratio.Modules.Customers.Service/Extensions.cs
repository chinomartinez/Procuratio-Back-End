using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Customers.DataAccess;

namespace Procuratio.Modules.Customers.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddCustomersServices(this IServiceCollection services)
        {
            //services.AddScoped<INTERFAZSERVICIO, CLASESERVICIO>();
            //services.AddSingleton<INTERFAZREPOSITORIO, REPOSITORIO>();

            services.AddDatabase();

            return services;
        }
    }
}
