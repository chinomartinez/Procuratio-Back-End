using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Customers.DataAccess.EF.Repositories;
using Procuratio.Modules.Customers.DataAccess.EF.Repositories.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.Middleware;
using Procuratio.Shared.Infrastructure.SQLServer;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Customers.Service")]
namespace Procuratio.Modules.Customers.DataAccess
{
    internal static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddSQLServer<CustomersDbContext>();

            return services;
        }

        public static IApplicationBuilder AddDatabase(this IApplicationBuilder app)
        {
            app.AddSeedDataBase<CustomersDbContext>();

            return app;
        }
    }
}
