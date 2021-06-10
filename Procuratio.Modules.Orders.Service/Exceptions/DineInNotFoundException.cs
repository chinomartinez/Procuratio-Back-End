using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class DineInNotFoundException : CustomExceptionBase
    {
        public DineInNotFoundException() : base(message: $"La Comida en Restaurante no fue encontrada.") { }
    }
}
