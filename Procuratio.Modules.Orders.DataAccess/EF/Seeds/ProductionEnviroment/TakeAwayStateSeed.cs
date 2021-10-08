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

            takeAwayStateDbSet.AddRange(
                new TakeAwayState() { Id = (short)TakeAwayState.State.InProgress, StateName = "En curso" },
                new TakeAwayState() { Id = (short)TakeAwayState.State.Completed, StateName = "Completado" },
                new TakeAwayState() { Id = (short)TakeAwayState.State.DidNotCome, StateName = "No vino" });
        }
    }
}
