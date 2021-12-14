using System.Threading.Tasks;

namespace Procuratio.Shared.Abstractions.Events
{
    public interface IEventDispacher
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : class, IEvent;
    }
}
