using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class MenuSubCategoryStateSeed
    {
        internal static void StartMenuSubCategoryStateSeed(DbSet<MenuSubCategoryState> MenuSubCategoryStateDbSet)
        {
            if (MenuSubCategoryStateDbSet.Any()) return;

            MenuSubCategoryStateDbSet.AddRange(
                new MenuSubCategoryState() { Id = (short)MenuSubCategoryState.State.Available, StateName = "Disponible" },
                new MenuSubCategoryState() { Id = (short)MenuSubCategoryState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
