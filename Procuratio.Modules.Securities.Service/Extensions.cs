using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Securities.DataAccess;
using Procuratio.Modules.Securities.Service.Services;
using Procuratio.Modules.Securities.Service.Services.Interfaces;

namespace Procuratio.Modules.Securities.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddSecuritiesServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaruantService, RestaruantService>();
            services.AddScoped<IRoleClaimService, RoleClaimService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserClaimService, UserClaimService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IUserTokenService, UserTokenService>();
            services.AddScoped<IUserService, UserService>();

            services.AddDatabase();

            return services;
        }
    }
}
