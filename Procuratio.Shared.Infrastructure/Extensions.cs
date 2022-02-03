using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.Shared.Infrastructure.API;
using Procuratio.Shared.Infrastructure.Events;
using Procuratio.Shared.Infrastructure.Exceptions;
using Procuratio.Shared.Infrastructure.Messaging;
using Procuratio.Shared.Infrastructure.Modules;
using Procuratio.Shared.Infrastructure.SQLServer;
using Procuratio.Shared.Infrastructure.Tenant;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(item: new InternalControllerFeatureProvider());
                });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ErrorHandlerMiddleware>();
            services.AddSQLServer();
            services.AddEvents();
            services.AddMessaging();
            services.AddModuleRequests();
            services.AddTenant();

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();

            return app;
        }

        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
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
