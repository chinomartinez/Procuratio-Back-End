using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Securities.DataAccess;
using Procuratio.Modules.Securities.Service.Services.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.Services.MicrosoftIdentity;
using Procuratio.Modules.Securities.Service.ValidateChangeState;
using Procuratio.Modules.Securities.Service.ValidateChangeState.Interfaces;
using System.Reflection;

namespace Procuratio.Modules.Securities.Service
{
    public static class Extensions
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            services.AddScoped<IRoleClaimService, RoleClaimService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserClaimService, UserClaimService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IUserTokenService, UserTokenService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(Extensions).GetTypeInfo().Assembly);

            services.AddScoped<IValidateChangeStateUser, ValidateChangeStateUser>();

            services.AddDatabase();

            return services;
        }

        public static IApplicationBuilder AddSecurityApps(this IApplicationBuilder app)
        {
            app.AddDatabase();

            return app;
        }
    }
}
