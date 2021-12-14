using System;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Modules
{
    public sealed class ModuleBroadcastRegistration
    {
        public Type TagetType { get; }

        public Func<object, Task> Handle { get; }

        public string Key => TagetType.Name;

        public ModuleBroadcastRegistration(Type targetType, Func<object, Task> handle)
        {
            TagetType = targetType;
            Handle = handle;
        }
    }
}
