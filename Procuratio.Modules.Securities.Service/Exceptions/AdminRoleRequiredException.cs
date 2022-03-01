using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Service.Exceptions
{
    internal class AdminRoleRequiredException : CustomExceptionBase
    {
        public AdminRoleRequiredException() : base(message: $"Su usuario no tiene un rol de administrador.") { }
    }
}
