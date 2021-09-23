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

            reserveStateDbSet.AddAsync(new ReserveState() { Id = (short)ReserveState.State.Pending, StateName = "Pendiente" });

            reserveStateDbSet.AddAsync(new ReserveState() { Id = (short)ReserveState.State.Unconfirmed, StateName = "Sin confirmar" });

            reserveStateDbSet.AddAsync(new ReserveState() { Id = (short)ReserveState.State.InProgress, StateName = "En curso" });

            reserveStateDbSet.AddAsync(new ReserveState() { Id = (short)ReserveState.State.Completed, StateName = "Completada" });

            reserveStateDbSet.AddAsync(new ReserveState() { Id = (int)ReserveState.State.DidNotCome, StateName = "No vino" });
        }
    }
}
