using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.ProcuratioFramework.Exception
{
    internal class HttpContextNullException : CustomExceptionBase
    {
        public HttpContextNullException(string message) : base(message: $"No se encontraron los datos de la sesión {message}.") { }
    }
}
