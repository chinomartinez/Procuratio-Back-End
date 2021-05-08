using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Orders.DataAccess;
using Procuratio.Modules.Orders.Service.Services;
using Procuratio.Modules.Orders.Service.Services.Interfaces;

namespace Procuratio.Modules.Orders.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IDinerInService, DinerInService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReserveService, ReserveService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<ITakeAwayService, TakeAwayService>();

            services.AddDatabase();

            return services;
        }

        public static IApplicationBuilder AddOrdersApps(this IApplicationBuilder app)
        {
            app.AddDatabase();

            return app;
        }
    }
}
