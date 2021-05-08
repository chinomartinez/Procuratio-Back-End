using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Cashes.DataAccess;
using Procuratio.Modules.Cashes.Service.Services;
using Procuratio.Modules.Cashes.Service.Services.Interfaces;

namespace Procuratio.Modules.Cashes.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddCashesServices(this IServiceCollection services)
        {
            services.AddScoped<ICashService, CashService>();
            services.AddScoped<IMountTypeService, MountTypeService>();

            services.AddDatabase();

            return services;
        }

        public static IApplicationBuilder AddCashesApps(this IApplicationBuilder app)
        {
            app.AddDatabase();

            return app;
        }
    }
}
