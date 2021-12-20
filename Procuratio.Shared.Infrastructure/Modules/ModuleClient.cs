using Procuratio.Shared.Abstractions.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Modules
{
    internal sealed class ModuleClient : IModuleClient
    {
        private readonly IModuleRegistry _moduleRegistry;

        public ModuleClient(IModuleRegistry moduleRegistry) => _moduleRegistry = moduleRegistry;

        public async Task PublishAsync(object message)
        {
            string key = message.GetType().Name;

            List<ModuleBroadcastRegistration> registrations = _moduleRegistry.GetModuleBroadcastRegistration(key).ToList();

            List<Task> task = new();

            registrations.ForEach(x =>
            {
                Func<object, Task> handle = x.Handle;
                var translatedMessage = TranslateType(message, x.TagetType);

                task.Add(handle(translatedMessage));
            });

            await Task.WhenAll(task);
        }

        public static object TranslateType(object @object, Type targetType)
         => JsonSerializer.Deserialize(JsonSerializer.Serialize(@object), targetType);
    }
}
