using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class ItemXPromotionStateSeed
    {
        internal static void StartCategoryItemStateSeed(DbSet<ItemXPromotionState> itemXPromotionStateDbSet)
        {
            if (itemXPromotionStateDbSet.Any()) return;

            itemXPromotionStateDbSet.Add(new ItemXPromotionState() { StateName = "Disponible" });
            MenuesSeedStart.SaveChangesForSeed();

            itemXPromotionStateDbSet.Add(new ItemXPromotionState() { StateName = "Eliminado" });
            MenuesSeedStart.SaveChangesForSeed();
        }
    }
}
