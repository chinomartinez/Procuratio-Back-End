using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Notification.API.Exceptions
{
    public class TablesNotFoundException : CustomExceptionBase
    {
        public TablesNotFoundException() : base(message: "El sistema no pudo encontrar las mesas pertenecientes a tu pedido") { }
    }
}
