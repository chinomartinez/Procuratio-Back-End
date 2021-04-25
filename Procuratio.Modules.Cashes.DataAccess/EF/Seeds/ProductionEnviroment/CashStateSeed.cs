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

            cashStateDbSet.Add(new CashState() { ID = (int)CashState.State.Active, StateName = "Activa" });

            cashStateDbSet.Add(new CashState() { ID = (int)CashState.State.Inactive, StateName = "Inactiva" });

            cashStateDbSet.Add(new CashState() { ID = (int)CashState.State.CashClosed, StateName = "Caja cerrada" });
        }
    }
}
