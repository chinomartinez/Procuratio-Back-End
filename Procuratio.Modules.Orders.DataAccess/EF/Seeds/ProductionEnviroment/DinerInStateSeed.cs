using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class DinerInStateSeed
    {
        internal static void StartDinerInStateSeed(DbSet<DinerInState> dinerInStateDbSet)
        {
            if (dinerInStateDbSet.Any()) return;

            dinerInStateDbSet.Add(new DinerInState() { ID = (short)DinerInState.State.InProgress, StateName = "En curso" });

            dinerInStateDbSet.Add(new DinerInState() { ID = (short)DinerInState.State.Completed, StateName = "Completada" });
        }
    }
}
