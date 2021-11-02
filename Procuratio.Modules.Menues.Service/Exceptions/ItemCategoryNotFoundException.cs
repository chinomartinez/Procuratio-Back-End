using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.Exceptions
{
    internal class ItemCategoryNotFoundException : CustomExceptionBase
    {
        public ItemCategoryNotFoundException() : base(message: $"La Categoria del item no fue encontrada.") { }
    }
}
