using System.Threading.Tasks;

namespace Procuratio.Shared.Abstractions.Messaging
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IMessage[] messages);
    }
}
