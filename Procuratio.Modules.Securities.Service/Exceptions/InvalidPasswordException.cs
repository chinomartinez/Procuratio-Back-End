using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Security.Service.Exceptions
{
    internal class InvalidPasswordException : CustomExceptionBase
    {
        public InvalidPasswordException() : base(message: $"La contraseña actual es invalida.") { }
    }
}
