using Procuratio.Shared.Abstractions.Messaging;
using System.Threading.Channels;

namespace Procuratio.Shared.Infrastructure.Messaging
{
    public interface IMessageChannel
    {
        ChannelReader<IMessage> Reader { get; }

        ChannelWriter<IMessage> Writer { get; }
    }
}
