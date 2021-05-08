using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.MicrosoftIdentity;
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
            services.AddScoped<IRoleClaimRepository, RoleClaimRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserClaimRepository, UserClaimRepository>();
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            services.AddScoped<IUserXRolRepository, UserXRolRepository>();

            services.AddSQLServer<SecuritiesDbContext>();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<SecuritiesDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
