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

            reserveStateDbSet.Add(new ReserveState() { StateName = "Pendiente" });
            OrdersSeedStart.SaveChangesForSeed();

            reserveStateDbSet.Add(new ReserveState() { StateName = "Sin confirmar" });
            OrdersSeedStart.SaveChangesForSeed();

            reserveStateDbSet.Add(new ReserveState() { StateName = "En curso" });
            OrdersSeedStart.SaveChangesForSeed();

            reserveStateDbSet.Add(new ReserveState() { StateName = "Completada" });
            OrdersSeedStart.SaveChangesForSeed();

            reserveStateDbSet.Add(new ReserveState() { StateName = "No vino" });
            OrdersSeedStart.SaveChangesForSeed();
        }
    }
}
