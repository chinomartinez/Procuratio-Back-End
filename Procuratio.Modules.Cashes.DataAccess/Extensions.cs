using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Cashes.DataAccess.EF.Repositories;
using Procuratio.Modules.Cashes.DataAccess.EF.Repositories.Interfaces;
using Procuratio.ProcuratioFramework.ProcuratioFramework.Middleware;
using Procuratio.Shared.Infrastructure.SQLServer;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Cashes.Service")]
namespace Procuratio.Modules.Cashes.DataAccess
{
    internal static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<ICashRepository, CashRepository>();
            services.AddScoped<IMountTypeRepository, MountTypeRepository>();

            services.AddSQLServer<CashesDbContext>();

            return services;
        }

        public static IApplicationBuilder AddDatabase(this IApplicationBuilder app)
        {
            app.AddSeedDataBase<CashesDbContext>();

            return app;
        }
    }
}
