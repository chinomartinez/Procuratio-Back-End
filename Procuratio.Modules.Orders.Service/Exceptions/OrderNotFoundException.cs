using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class OrderNotFoundException : CustomExceptionBase
    {
        public OrderNotFoundException() : base(message: $"La Orden no fue encontrada.") { }
    }
}
