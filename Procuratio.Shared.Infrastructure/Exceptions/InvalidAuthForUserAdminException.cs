using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Exceptions
{
    public class InvalidAuthForUserAdminException : CustomExceptionBase
    {
        public InvalidAuthForUserAdminException() : base(message: $"Su usario debe iniciar sesíon como administrador.") { }
    }
}
