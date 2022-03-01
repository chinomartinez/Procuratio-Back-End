using Procuratio.Shared.Abstractions.Exceptions;

namespace Procuratio.Shared.Infrastructure.Exceptions
{
    public class BranchIdNotFoundException : CustomExceptionBase
    {
        public BranchIdNotFoundException() : base(message: $"No se encontro el identificador de la sucursal.") { }
    }
}
