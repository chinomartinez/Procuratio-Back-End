using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            reserveStateDbSet.Add(new ReserveState() { StateName = "Eliminada" });
            OrdersSeedStart.SaveChangesForSeed();

            reserveStateDbSet.Add(new ReserveState() { StateName = "Completada" });
            OrdersSeedStart.SaveChangesForSeed();

            reserveStateDbSet.Add(new ReserveState() { StateName = "No vino" });
            OrdersSeedStart.SaveChangesForSeed();
        }
    }
}
