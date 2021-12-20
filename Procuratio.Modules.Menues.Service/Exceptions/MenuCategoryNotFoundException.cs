using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Menu.Service.Exceptions
{
    internal class MenuCategoryNotFoundException : CustomExceptionBase
    {
        public MenuCategoryNotFoundException() : base(message: $"La Categoria del menu no fue encontrada.") { }
    }
}
