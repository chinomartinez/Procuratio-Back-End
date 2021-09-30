using Procuratio.Shared.Abstractions.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Modules
{
    internal sealed class ModuleRegistry : IModuleRegistry
    {
        public readonly List<ModuleBroadcastRegistration> _broadcastRegistration = new();

        public IEnumerable<ModuleBroadcastRegistration> GetModuleBroadcastRegistration(string key)
         => _broadcastRegistration.Where(x => x.Key == key);

        public void AddBroadcastRegistration(ModuleBroadcastRegistration registration)
        {
            if (registration is null) { throw new InvalidOperationException("Empty broadcast registration"); }

            if (string.IsNullOrWhiteSpace(registration.TagetType.Namespace)) { throw new InvalidOperationException("Missing target type namespace"); }

            _broadcastRegistration.Add(registration);
        }
    }
}
