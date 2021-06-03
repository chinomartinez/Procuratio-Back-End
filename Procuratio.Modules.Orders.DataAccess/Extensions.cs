using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.Middleware;
using Procuratio.Shared.Infrastructure.SQLServer;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Orders.Service")]
namespace Procuratio.Modules.Orders.DataAccess
{
    internal static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IDineInRepository, DineInRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IReserveRepository, ReserveRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<ITakeAwayRepository, TakeAwayRepository>();

            services.AddSQLServer<OrdersDbContext>();

            return services;
        }

        public static IApplicationBuilder AddDatabase(this IApplicationBuilder app)
        {
            app.AddSeedDataBase<OrdersDbContext>();

            return app;
        }
    }
}
