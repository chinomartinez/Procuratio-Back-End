using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class TakeAwayStateSeed
    {
        internal static void StartTakeAwayStateSeed(DbSet<TakeAwayState> takeAwayStateDbSet)
        {
            if (takeAwayStateDbSet.Any()) return;

            takeAwayStateDbSet.Add(new TakeAwayState() { ID = (short)TakeAwayState.State.InProgress, StateName = "En curso" });

            takeAwayStateDbSet.Add(new TakeAwayState() { ID = (short)TakeAwayState.State.Completed, StateName = "Completado" });

            takeAwayStateDbSet.Add(new TakeAwayState() { ID = (short)TakeAwayState.State.DidNotCome, StateName = "No vino" });
        }
    }
}
