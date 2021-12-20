using Microsoft.Extensions.DependencyInjection;
using Procuratio.Shared.Abstractions.Events;
using Procuratio.Shared.Abstractions.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Modules
{
    internal static class Extensions
    {
        public static IServiceCollection AddModuleRequests(this IServiceCollection services)
        {
            services.AddModuleRegistry();

            services.AddSingleton<IModuleClient, ModuleClient>();

            return services;
        }

        public static void AddModuleRegistry(this IServiceCollection services)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            List<Type> eventTypes = assemblies.SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass && typeof(IEvent).IsAssignableFrom(x))
                .ToList();

            services.AddSingleton<IModuleRegistry>(sp =>
            {
                ModuleRegistry registry = new();
                IEventDispacher eventDispacher = sp.GetRequiredService<IEventDispacher>();

                eventTypes.ForEach(x =>
                {
                    Type targetType = x;

                    ModuleBroadcastRegistration registration = new(targetType, Handle);
                    registry.AddBroadcastRegistration(registration);

                    Task Handle(object @event) => (Task)eventDispacher.GetType()
                        .GetMethod(nameof(IEventDispacher.PublishAsync))
                        ?.MakeGenericMethod(x).Invoke(eventDispacher, new[] { @event });
                });

                return registry;
            });
        }
    }
}
