using Procuratio.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Exceptions
{
    public class BranchIdNotFoundException : CustomExceptionBase
    {
        public BranchIdNotFoundException() : base(message: $"No se encontro el identificador del usuario asociado al restaurante.") { }
    }
}
