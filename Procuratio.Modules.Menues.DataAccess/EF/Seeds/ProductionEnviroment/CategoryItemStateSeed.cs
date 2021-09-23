using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class CategoryItemStateSeed
    {
        internal static void StartCategoryItemStateSeed(DbSet<CategoryItemState> categoryItemStateDbSet)
        {
            if (categoryItemStateDbSet.Any()) return;

            categoryItemStateDbSet.Add(new CategoryItemState() { Id = (short)CategoryItemState.State.Available, StateName = "Disponible" });

            categoryItemStateDbSet.Add(new CategoryItemState() { Id = (short)CategoryItemState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
