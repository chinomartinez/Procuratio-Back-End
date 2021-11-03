using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.Exceptions
{
    internal class MenuCategoryNotFoundException : CustomExceptionBase
    {
        public MenuCategoryNotFoundException() : base(message: $"La Categoria del menu no fue encontrada.") { }
    }
}
