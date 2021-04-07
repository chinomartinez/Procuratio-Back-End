using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.ProcuratioFramework.ProcuratioFramework.Middleware;
using Procuratio.Shared.Infrastructure.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Customers.Service")]
namespace Procuratio.Modules.Customers.DataAccess
{
    internal static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
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
