using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Procuratio.API.Modules.Notification.API.Services;
using Procuratio.Modules.Notification.Shared;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "Procuratio.API")]
namespace Procuratio.API.Modules.Notification.API
{
    internal static class NotificationModule
    {
        public static IServiceCollection AddNotificationModule(this IServiceCollection services)
        {
            services.AddTransient<INotificationModuleAPI, NotificationModuleAPI>();
            //services.AddSingleton<ICustomerMenuSenderHub, CustomerMenuSenderHub>();

            services.AddSignalR();

            return services;
        }

        public static IApplicationBuilder UseNotificationModule(this IApplicationBuilder app)
        {
            app.UseSignalR(c =>
            {
                c.MapHub<CustomerMenuSender>("/CustomerMenuSender");
            });

            return app;
        }
    }
}
