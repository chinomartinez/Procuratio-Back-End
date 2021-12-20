using Procuratio.Shared.Infrastructure.Modules;
using System.Collections.Generic;

namespace Procuratio.Shared.Abstractions.Modules
{
    public interface IModuleRegistry
    {
        IEnumerable<ModuleBroadcastRegistration> GetModuleBroadcastRegistration(string key);

        void AddBroadcastRegistration(ModuleBroadcastRegistration registration);
    }
}
