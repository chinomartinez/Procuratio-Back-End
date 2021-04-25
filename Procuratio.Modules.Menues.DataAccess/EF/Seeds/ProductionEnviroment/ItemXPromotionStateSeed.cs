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

            itemXPromotionStateDbSet.Add(new ItemXPromotionState() { ID = (int)ItemXPromotionState.State.Available, StateName = "Disponible" });

            itemXPromotionStateDbSet.Add(new ItemXPromotionState() { ID = (int)ItemXPromotionState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
