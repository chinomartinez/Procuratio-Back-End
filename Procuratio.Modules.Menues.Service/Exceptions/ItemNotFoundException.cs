using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Menu.Service.Exceptions
{
    public class ItemNotFoundException : CustomExceptionBase
    {
        public ItemNotFoundException() : base(message: $"El articulo no fue encontrado.") { }
    }
}
