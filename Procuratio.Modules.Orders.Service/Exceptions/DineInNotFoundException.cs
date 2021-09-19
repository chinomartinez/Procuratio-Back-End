using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class DineInNotFoundException : CustomExceptionBase
    {
        public DineInNotFoundException() : base(message: $"La comida en restaurante no fue encontrada.") { }
    }
}
