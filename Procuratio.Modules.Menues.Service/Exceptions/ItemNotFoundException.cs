using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.Exceptions
{
    public class ItemNotFoundException : CustomExceptionBase
    {
        public ItemNotFoundException() : base(message: $"El articulo no fue encontrado.") { }
    }
}
