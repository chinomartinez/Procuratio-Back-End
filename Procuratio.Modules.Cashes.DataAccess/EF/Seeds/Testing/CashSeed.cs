using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Cashes.Domain.Entities;
using System.Linq;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Seeds.Testing
{
    internal class CashSeed
    {
        internal static void StartCasheed(DbSet<Cash> cashDbSet)
        {
            if (cashDbSet.Any()) return;

            // Adding...
        }
    }
}
