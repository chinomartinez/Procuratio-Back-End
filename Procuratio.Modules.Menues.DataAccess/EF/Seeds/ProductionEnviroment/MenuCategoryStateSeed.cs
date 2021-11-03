using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class MenuCategoryStateSeed
    {
        internal static void StartMenuCategoryStateSeed(DbSet<MenuCategoryState> menuCategoryStateDbSet)
        {
            if (menuCategoryStateDbSet.Any()) return;

            menuCategoryStateDbSet.AddRange(
                new MenuCategoryState() { Id = (short)MenuCategoryState.State.Available, StateName = "Disponible" },
                new MenuCategoryState() { Id = (short)MenuCategoryState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
