using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Orders.DataAccess;
using Procuratio.Modules.Orders.Service.Mappers.DinerInMappers;
using Procuratio.Modules.Orders.Service.Services;
using Procuratio.Modules.Orders.Service.Services.Interfaces;
using Procuratio.Modules.Orders.Service.ValidateChangeState;
using Procuratio.Modules.Orders.Service.ValidateChangeState.Interfaces;
using System.Reflection;

namespace Procuratio.Modules.Orders.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddOrderServices(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IDineInService, DineInService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReserveService, ReserveService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<ITakeAwayService, TakeAwayService>();

            services.AddAutoMapper(typeof(Extensions).GetTypeInfo().Assembly);

            services.AddSingleton<IValidateChangeStateDineIn, ValidateChangeStateDineIn>();
            services.AddSingleton<IValidateChangeStateOrder, ValidateChangeStateOrder>();
            services.AddSingleton<IValidateChangeStateTable, ValidateChangeStateTable>();

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
