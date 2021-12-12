using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Exceptions
{
    internal class PropertyNotFoundException : CustomExceptionBase
    {
        public PropertyNotFoundException(string propertyName) : base(message: $"No se encontro el campo con el nombre '{propertyName}'.") { }
    }
}
