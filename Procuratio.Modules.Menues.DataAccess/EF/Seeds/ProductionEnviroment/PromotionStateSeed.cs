using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class PromotionStateSeed
    {
        internal static void StartPromotionStateSeed(DbSet<PromotionState> PromotionStateDbSet)
        {
            if (PromotionStateDbSet.Any()) return;

            PromotionStateDbSet.Add(new PromotionState() { ID = (int)PromotionState.State.Available, StateName = "Disponible" });

            PromotionStateDbSet.Add(new PromotionState() { ID = (int)PromotionState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
