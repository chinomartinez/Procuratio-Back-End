using Microsoft.Extensions.DependencyInjection;
using Procuratio.Shared.Abstractions.Messaging;

namespace Procuratio.Shared.Infrastructure.Messaging
{
    internal static class Extensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            MessagingOptions options = services.GetOptions<MessagingOptions>("messaging");

            services.AddSingleton(options);
            services.AddSingleton<IMessageBroker, InMemoryMessageBroker>();
            services.AddSingleton<IMessageChannel, MessageChannel>();
            services.AddSingleton<IAsynchronusDispacher, AsynchronusDispacher>();

            if (options.UseBackgroundDispacher) { services.AddHostedService<AsynchronusDispacherJob>(); }

            return services;
        }
    }
}
