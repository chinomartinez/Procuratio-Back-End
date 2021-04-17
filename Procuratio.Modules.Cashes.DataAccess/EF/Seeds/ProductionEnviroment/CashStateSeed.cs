using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Cashes.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class CashStateSeed
    {
        internal static void StartCashStateSeed(DbSet<CashState> cashStateDbSet)
        {
            if (cashStateDbSet.Any()) return;

            cashStateDbSet.Add(new CashState() { StateName = "Activa" });
            CashesSeedStart.SaveChangesForSeed();

            cashStateDbSet.Add(new CashState() { StateName = "Inactiva" });
            CashesSeedStart.SaveChangesForSeed();

            cashStateDbSet.Add(new CashState() { StateName = "Caja cerrada" });
            CashesSeedStart.SaveChangesForSeed();
        }
    }
}
