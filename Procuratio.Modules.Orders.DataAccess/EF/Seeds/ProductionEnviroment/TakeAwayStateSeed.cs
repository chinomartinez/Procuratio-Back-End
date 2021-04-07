using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class TakeAwayStateSeed
    {
        internal static void StartTakeAwayStateSeed(DbSet<TakeAwayState> takeAwayStateDbSet)
        {
            if (takeAwayStateDbSet.Any()) return;

            takeAwayStateDbSet.Add(new TakeAwayState() { StateName = "Completado" });
            OrdersSeedStart.SaveChangesForSeed();

            takeAwayStateDbSet.Add(new TakeAwayState() { StateName = "No vino" });
            OrdersSeedStart.SaveChangesForSeed();

            takeAwayStateDbSet.Add(new TakeAwayState() { StateName = "Eliminado" });
            OrdersSeedStart.SaveChangesForSeed();
        }
    }
}
