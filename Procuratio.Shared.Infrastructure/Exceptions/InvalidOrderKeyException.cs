using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Shared.Infrastructure.Exceptions
{
    public class InvalidOrderKeyException : CustomExceptionBase
    {
        public InvalidOrderKeyException() : base(message: "La contraseña proporcionada no es valida") { }
    }
}
