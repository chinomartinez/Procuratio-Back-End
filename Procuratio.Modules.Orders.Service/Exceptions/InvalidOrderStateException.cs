using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class InvalidOrderStateException : CustomExceptionBase
    {
        public InvalidOrderStateException(string exceptionDetailmessage) : base(message: exceptionDetailmessage) { }
    }
}
