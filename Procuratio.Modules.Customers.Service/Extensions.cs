using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Customers.DataAccess;
using Procuratio.Modules.Customers.Service.Services;
using Procuratio.Modules.Customers.Service.Services.Interfaces;

namespace Procuratio.Modules.Customers.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddCustomersServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddDatabase();

            return services;
        }

        public static IApplicationBuilder AddCustomersApps(this IApplicationBuilder app)
        {
            app.AddDatabase();

            return app;
        }
    }
}
