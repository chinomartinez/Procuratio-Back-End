using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Security.DataAccess.EF.CustomMicrosoftIdentityImplementations;
using Procuratio.Modules.Security.DataAccess.EF.Seeds.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.Middleware;
using Procuratio.Shared.Infrastructure.SQLServer;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.Modules.Security.Service")]
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

            services.AddSQLServer<SecurityDbContext>();

            services.AddIdentity<User, Role>(config =>
            {
                config.Password = new PasswordOptions()
                {
                    RequireDigit = false,
                    RequiredLength = 5,
                    RequireNonAlphanumeric = false,
                    RequireUppercase = false,
                    RequireLowercase = false
                };

                config.Lockout = new LockoutOptions()
                {
                    AllowedForNewUsers = false
                };

                config.SignIn = new SignInOptions()
                {
                    RequireConfirmedPhoneNumber = false,
                    RequireConfirmedAccount = false,
                    RequireConfirmedEmail = false
                };
            })
            .AddEntityFrameworkStores<SecurityDbContext>()
            .AddSignInManager<CustomSignInManager>()
            .AddUserManager<CustomUserManager>()
            .AddUserStore<CustomUserStore>()
            .AddDefaultTokenProviders();

            services.AddScoped<CustomSignInManager>();
            services.AddScoped<CustomUserManager>();
            services.AddScoped<CustomUserStore>();

            services.AddScoped<MicrosoftIdentitySeeder>();

            return services;
        }

        public static IApplicationBuilder AddDatabase(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.AddSeedDataBase<SecurityDbContext>();

            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                MicrosoftIdentitySeeder microsoftIdentitySeeder = scope.ServiceProvider.GetService<MicrosoftIdentitySeeder>();
                Task.Run(() => MicrosoftIdentitySeeder.EnsureSeedDataAsync(scope)).Wait();
            }

            return app;
        }
    }
}
