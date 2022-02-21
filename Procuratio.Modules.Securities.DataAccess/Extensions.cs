using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Procuratio.Modules.Securities.DataAccess.EF.JWT;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.Interfaces.MicrosoftIdentity;
using Procuratio.Modules.Securities.DataAccess.EF.Repositories.MicrosoftIdentity;
using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.Modules.Security.DataAccess.EF.CustomMicrosoftIdentityImplementations;
using Procuratio.Modules.Security.DataAccess.EF.Seeds.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.Middleware;
using Procuratio.Shared.Infrastructure.SQLServer;
using System;
using System.Runtime.CompilerServices;
using System.Text;
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
            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            services.AddScoped<IUserXRolRepository, UserXRolRepository>();

            services.AddSQLServer<SecurityDbContext>();

            JsonWebToken JWToptions = services.GetOptions<JsonWebToken>(sectionName: nameof(JsonWebToken));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWToptions.Key)),
                    ClockSkew = TimeSpan.Zero
                });

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
