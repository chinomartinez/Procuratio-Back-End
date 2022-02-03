using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Order.Service.Exceptions
{
    internal class InvalidPasswordException : CustomExceptionBase
    {
        public InvalidPasswordException() : base(message: "La contraseña proporcionada no es valida") { }
    }
}
