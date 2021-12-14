using Procuratio.Shared.Abstractions.Messaging;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Messaging
{
    public interface IAsynchronusDispacher
    {
        Task PublishAsync<TMessage>(TMessage message) where TMessage : class, IMessage;
    }
}
