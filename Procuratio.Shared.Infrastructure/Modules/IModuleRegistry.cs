using Procuratio.Shared.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Abstractions.Modules
{
    public interface IModuleRegistry
    {
        IEnumerable<ModuleBroadcastRegistration> GetModuleBroadcastRegistration(string key);

        void AddBroadcastRegistration(ModuleBroadcastRegistration registration);
    }
}
