using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class OrderNotFoundException : CustomExceptionBase
    {
        public OrderNotFoundException() : base(message: $"La Orden no fue encontrada.") { }
    }
}
