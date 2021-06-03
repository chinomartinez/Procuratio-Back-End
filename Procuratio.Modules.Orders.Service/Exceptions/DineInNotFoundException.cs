using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class DineInNotFoundException : CustomExceptionBase
    {
        public DineInNotFoundException() : base(message: $"La Comida en Restaurante no fue encontrada.") { }
    }
}
