using Procuratio.Shared.Abstractions.Messaging;
using Procuratio.Shared.Abstractions.Modules;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Messaging
{
    internal sealed class InMemoryMessageBroker : IMessageBroker
    {
        private readonly IModuleClient _moduleClient;
        private readonly IAsynchronusDispacher _asynchronusDispacher;
        private readonly MessagingOptions _messagingOptions;

        public InMemoryMessageBroker(IModuleClient moduleClient, MessagingOptions messagingOptions, IAsynchronusDispacher asynchronusDispacher)
        {
            _moduleClient = moduleClient;
            _messagingOptions = messagingOptions;
            _asynchronusDispacher = asynchronusDispacher;
        }

        public async Task PublishAsync(params IMessage[] messages)
        {
            if (messages is null) { return; }

            messages = messages.Where(x => x is not null).ToArray();

            if (!messages.Any()) { return; }

            IEnumerable<Task> tasks = messages.Select(x => _messagingOptions.UseBackgroundDispacher
            ? _asynchronusDispacher.PublishAsync(x)
            : _moduleClient.PublishAsync(x));

            await Task.WhenAll(tasks);
        }
    }
}
