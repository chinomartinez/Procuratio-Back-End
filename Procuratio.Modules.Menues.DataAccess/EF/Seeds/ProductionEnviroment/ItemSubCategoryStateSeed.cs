using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class ItemSubCategoryStateSeed
    {
        internal static void StartItemSubCategoryStateSeed(DbSet<ItemSubCategoryState> itemSubCategoryStateDbSet)
        {
            if (itemSubCategoryStateDbSet.Any()) return;

            itemSubCategoryStateDbSet.AddRange(
                new ItemSubCategoryState() { Id = (short)ItemSubCategoryState.State.Available, StateName = "Disponible" },
                new ItemSubCategoryState() { Id = (short)ItemSubCategoryState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
