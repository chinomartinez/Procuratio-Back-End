using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class DinerInStateSeed
    {
        internal static void StartDineInStateSeed(DbSet<DineInState> dineInStateDbSet)
        {
            if (dineInStateDbSet.Any()) return;

            dineInStateDbSet.Add(new DineInState() { ID = (short)DineInState.State.InProgress, StateName = "En curso" });

            dineInStateDbSet.Add(new DineInState() { ID = (short)DineInState.State.Completed, StateName = "Completada" });
        }
    }
}
