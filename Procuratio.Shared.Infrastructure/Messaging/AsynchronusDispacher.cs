using Procuratio.Shared.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Messaging
{
    internal sealed class AsynchronusDispacher : IAsynchronusDispacher
    {
        private readonly IMessageChannel _messageChannel;

        public AsynchronusDispacher(IMessageChannel messageChannel) => _messageChannel = messageChannel;

        public async Task PublishAsync<TMessage>(TMessage message) where TMessage : class, IMessage
         => await _messageChannel.Writer.WriteAsync(message);
    }
}
