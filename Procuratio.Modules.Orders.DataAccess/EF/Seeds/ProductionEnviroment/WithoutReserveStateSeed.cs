using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class WithoutReserveStateSeed
    {
        internal static void StartWithoutReserveStateSeed(DbSet<WithoutReserveState> withoutReserveStateDbSet)
        {
            if (withoutReserveStateDbSet.Any()) return;

            withoutReserveStateDbSet.AddRange(
                new WithoutReserveState() { Id = (short)WithoutReserveState.State.InProgress, StateName = "En curso" },
                new WithoutReserveState() { Id = (short)WithoutReserveState.State.Completed, StateName = "Completada" });
        }
    }
}
