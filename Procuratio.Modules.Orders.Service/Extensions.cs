using Microsoft.Extensions.DependencyInjection;

namespace Procuratio.Modules.Orders.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services)
        {
            //services.AddScoped<INTERFAZSERVICIO, CLASESERVICIO>();
            //services.AddSingleton<INTERFAZREPOSITORIO, REPOSITORIO>();

            return services;
        }
    }
}
