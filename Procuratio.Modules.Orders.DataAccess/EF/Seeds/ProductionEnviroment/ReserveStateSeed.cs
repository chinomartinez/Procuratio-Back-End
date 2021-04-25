using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class ReserveStateSeed
    {
        internal static void StartReserveStateSeed(DbSet<ReserveState> reserveStateDbSet)
        {
            if (reserveStateDbSet.Any()) return;

            reserveStateDbSet.Add(new ReserveState() { ID = (int)ReserveState.State.Pending, StateName = "Pendiente" });

            reserveStateDbSet.Add(new ReserveState() { ID = (int)ReserveState.State.Unconfirmed, StateName = "Sin confirmar" });

            reserveStateDbSet.Add(new ReserveState() { ID = (int)ReserveState.State.InProgress, StateName = "En curso" });

            reserveStateDbSet.Add(new ReserveState() { ID = (int)ReserveState.State.Completed, StateName = "Completada" });

            reserveStateDbSet.Add(new ReserveState() { ID = (int)ReserveState.State.DidNotCome, StateName = "No vino" });
        }
    }
}
