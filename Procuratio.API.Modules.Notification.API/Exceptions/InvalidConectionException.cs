using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Notification.API.Exceptions
{
    public class InvalidConectionException : CustomExceptionBase
    {
        public InvalidConectionException() : base(message: "Los datos proporcionados para la conection mozo-comensal no son validos.") { }
    }
}
