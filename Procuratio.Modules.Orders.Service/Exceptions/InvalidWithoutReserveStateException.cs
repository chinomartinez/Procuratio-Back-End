using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class InvalidWithoutReserveStateException : CustomExceptionBase
    {
        public InvalidWithoutReserveStateException(string exceptionDetailmessage) : base(message: exceptionDetailmessage) { }
    }
}
