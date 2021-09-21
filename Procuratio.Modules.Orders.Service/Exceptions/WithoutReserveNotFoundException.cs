using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class WithoutReserveNotFoundException : CustomExceptionBase
    {
        public WithoutReserveNotFoundException() : base(message: $"La comida en restaurante no fue encontrada.") { }
    }
}
