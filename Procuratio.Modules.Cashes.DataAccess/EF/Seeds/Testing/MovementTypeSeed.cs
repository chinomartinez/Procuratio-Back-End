using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Cashes.Domain.Entities;
using System.Linq;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Seeds.Testing
{
    internal class MovementTypeSeed
    {
        internal static void StartMovementTypeSeed(DbSet<MovementType> movementTypeDbSet)
        {
            if (movementTypeDbSet.Any()) return;

            // Adding...
        }
    }
}
