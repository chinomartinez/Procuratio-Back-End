using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class TableNotFoundException : CustomExceptionBase
    {
        public TableNotFoundException() : base(message: $"La Mesa no fue encontrada.") { }
    }
}
