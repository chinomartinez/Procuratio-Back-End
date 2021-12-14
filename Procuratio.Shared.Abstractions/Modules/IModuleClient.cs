using System.Threading.Tasks;

namespace Procuratio.Shared.Abstractions.Modules
{
    public interface IModuleClient
    {
        Task PublishAsync(object message);
    }
}
