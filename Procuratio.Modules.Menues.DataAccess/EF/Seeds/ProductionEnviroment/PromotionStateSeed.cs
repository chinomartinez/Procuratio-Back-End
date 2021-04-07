using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class PromotionStateSeed
    {
        internal static void StartPromotionStateSeed(DbSet<PromotionState> PromotionStateDbSet)
        {
            if (PromotionStateDbSet.Any()) return;

            PromotionStateDbSet.Add(new PromotionState() { StateName = "Disponible" });
            MenuesSeedStart.SaveChangesForSeed();

            PromotionStateDbSet.Add(new PromotionState() { StateName = "Eliminado" });
            MenuesSeedStart.SaveChangesForSeed();
        }
    }
}
