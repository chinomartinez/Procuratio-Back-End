using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Shared.Infrastructure.Exceptions
{
    internal class PropertyNotFoundException : CustomExceptionBase
    {
        public PropertyNotFoundException(string propertyName) : base(message: $"No se encontro el campo con el nombre '{propertyName}'.") { }
    }
}
