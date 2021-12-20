using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class InvalidOrderStateException : CustomExceptionBase
    {
        public InvalidOrderStateException(string exceptionDetailmessage) : base(message: exceptionDetailmessage) { }
    }
}
