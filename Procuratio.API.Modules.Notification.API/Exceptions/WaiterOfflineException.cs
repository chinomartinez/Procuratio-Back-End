using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Notification.API.Exceptions
{
    public class WaiterOfflineException : CustomExceptionBase
    {
        public WaiterOfflineException() : base(message: "El mozo a cargo de su pedido no esta logeado en la aplicacion para recibir su solicitud.") { }
    }
}
