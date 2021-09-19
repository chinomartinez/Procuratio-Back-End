using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Order.Service.Services;
using Procuratio.Modules.Order.Service.Services.Interfaces;
using Procuratio.Modules.Orders.DataAccess;
using Procuratio.Modules.Orders.Service.Services;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Order.API")]
namespace Procuratio.Modules.Orders.Service
{
    internal static class Extensions
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IDineInService, DineInService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReserveService, ReserveService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<ITakeAwayService, TakeAwayService>();

            services.AddAutoMapper(typeof(Extensions).GetTypeInfo().Assembly);

            services.AddDatabase();

            return services;
        }

        public static IApplicationBuilder AddOrderApps(this IApplicationBuilder app)
        {
            app.AddDatabase();

            return app;
        }
    }
}
