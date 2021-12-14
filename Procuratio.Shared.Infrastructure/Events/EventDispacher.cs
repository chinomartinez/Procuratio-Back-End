using Microsoft.Extensions.DependencyInjection;
using Procuratio.Shared.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Events
{
    internal sealed class EventDispacher : IEventDispacher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventDispacher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            using IServiceScope scope = _serviceProvider.CreateScope();

            IEnumerable<IEventHandler<TEvent>> handlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();

            IEnumerable<Task> tasks = handlers.Select(x => x.HandleAsync(@event));

            await Task.WhenAll(tasks);
        }
    }
}
