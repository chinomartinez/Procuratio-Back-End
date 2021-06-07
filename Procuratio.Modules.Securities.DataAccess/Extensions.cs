using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Procuratio.Modules.Securities.DataAccess.EF.JWT;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.Middleware;
using Procuratio.Shared.Infrastructure.SQLServer;
using System;
using System.Runtime.CompilerServices;
using System.Text;

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

            services.AddIdentity<User, Role>(config =>
            {
                config.Password = new PasswordOptions()
                {
                    RequireDigit = false,
                    RequiredLength = 5,
                    RequireNonAlphanumeric = false,
                    RequireUppercase = false
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
            .AddEntityFrameworkStores<SecuritiesDbContext>()
            .AddDefaultTokenProviders();

            JWTOptions options = services.GetOptions<JWTOptions>(sectionName: "JWTKey");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opciones =>
                opciones.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.JWTKey)),
                    ClockSkew = TimeSpan.Zero
                });

            return services;
        }

        public static IApplicationBuilder AddDatabase(this IApplicationBuilder app)
        {
            app.AddSeedDataBase<SecuritiesDbContext>();

            return app;
        }

        private static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
        {
            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            IConfiguration section = configuration.GetSection(sectionName);
            T options = new();

            section.Bind(options);

            return options;
        }
    }
}
