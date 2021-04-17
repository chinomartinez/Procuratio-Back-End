using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Shared.Infrastructure.SQLServer;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Securities.Service")]
namespace Procuratio.Modules.Securities.DataAccess
{
    internal static class Extensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddSQLServer<SecuritiesDbContext>();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<SecuritiesDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
