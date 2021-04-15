using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Cashes.Domain.Entities;
using System.Linq;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Seeds.Testing
{
    internal class MountTypeSeed
    {
        internal static void StartCashStateSeed(DbSet<MountType> mountTypeDbSet)
        {
            if (mountTypeDbSet.Any()) return;

            // Adding...
        }
    }
}
