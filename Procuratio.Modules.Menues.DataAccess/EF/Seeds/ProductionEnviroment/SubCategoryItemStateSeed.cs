using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class SubCategoryItemStateSeed
    {
        internal static void StartSubCategoryItemStateSeed(DbSet<SubCategoryItemState> subCategoryItemStateDbSet)
        {
            if (subCategoryItemStateDbSet.Any()) return;

            subCategoryItemStateDbSet.Add(new SubCategoryItemState() { ID = (int)SubCategoryItemState.State.Available, StateName = "Disponible" });

            subCategoryItemStateDbSet.Add(new SubCategoryItemState() { ID = (int)SubCategoryItemState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
