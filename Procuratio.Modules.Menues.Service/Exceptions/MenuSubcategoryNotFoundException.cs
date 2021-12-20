using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Menu.Service.Exceptions
{
    internal class MenuSubcategoryNotFoundException : CustomExceptionBase
    {
        public MenuSubcategoryNotFoundException() : base(message: $"La Subcategoria del menu no fue encontrada.") { }
    }
}
