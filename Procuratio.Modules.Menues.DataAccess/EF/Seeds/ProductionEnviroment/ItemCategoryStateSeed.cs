using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class ItemCategoryStateSeed
    {
        internal static void StartItemCategoryStateSeed(DbSet<ItemCategoryState> itemCategoryStateDbSet)
        {
            if (itemCategoryStateDbSet.Any()) return;

            itemCategoryStateDbSet.AddRange(
                new ItemCategoryState() { Id = (short)ItemCategoryState.State.Available, StateName = "Disponible" },
                new ItemCategoryState() { Id = (short)ItemCategoryState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
