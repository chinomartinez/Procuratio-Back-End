using Microsoft.Extensions.DependencyInjection;
using Procuratio.Shared.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Events
{
    internal static class Extensions
    {
        public static IServiceCollection AddEvents(this IServiceCollection services)
        {
            services.AddSingleton<IEventDispacher, EventDispacher>();

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            services.Scan(x => x.FromAssemblies(assemblies)
            .AddClasses(x => x.AssignableTo(typeof(IEventHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }
    }
}
