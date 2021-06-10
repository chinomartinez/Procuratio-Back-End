using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Modules.Securities.Service.Exceptions
{
    internal class UserNotFoundException : CustomExceptionBase
    {
        public UserNotFoundException() : base(message: $"El usuario en Restaurante no fue encontrada.") { }
    }
}
