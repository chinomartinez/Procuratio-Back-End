using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Service.Exceptions
{
    internal class InvalidDineInStateException : CustomExceptionBase
    {
        public InvalidDineInStateException(string exceptionDetailmessage) : base(message: exceptionDetailmessage) { }
    }
}
