using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Service.Exceptions
{
    internal class BranchNotFoundException : CustomExceptionBase
    {
        public BranchNotFoundException() : base(message: "Sucursal no encontrada") { }
    }
}
