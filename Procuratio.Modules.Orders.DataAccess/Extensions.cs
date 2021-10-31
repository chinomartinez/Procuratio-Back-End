using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Order.DataAccess.EF.Repositories;
using Procuratio.Modules.Order.DataAccess.EF.Repositories.Interfaces;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories;
using Procuratio.Modules.Orders.DataAccess.EF.Repositories.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.Middleware;
using Procuratio.Shared.Abstractions.Tenant;
using Procuratio.Shared.Infrastructure.SQLServer;
using Procuratio.Shared.Infrastructure.Tenant;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Order.Service")]
namespace Procuratio.Modules.Orders.DataAccess
{
    internal static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IWithoutReserveRepository, WithoutReserveRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IReserveRepository, ReserveRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<ITakeAwayRepository, TakeAwayRepository>();

            services.AddScoped<ITenantService, TenantService>();

            services.AddSQLServer<OrderDbContext>();

            return services;
        }

        public static IApplicationBuilder AddDatabase(this IApplicationBuilder app)
        {
            app.AddSeedDataBase<OrderDbContext>();

            return app;
        }
    }
}
