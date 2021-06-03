using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Service.Exceptions
{
    internal class UserNotFoundException : CustomExceptionBase
    {
        public UserNotFoundException() : base(message: $"El usuario en Restaurante no fue encontrada.") { }
    }
}
