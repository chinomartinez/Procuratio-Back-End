using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class SubCategoryItemStateSeed
    {
        internal static void StartCategoryItemStateSeed(DbSet<SubCategoryItemState> subCategoryItemStateDbSet)
        {
            if (subCategoryItemStateDbSet.Any()) return;

            subCategoryItemStateDbSet.Add(new SubCategoryItemState() { StateName = "Disponible" });
            MenuesSeedStart.SaveChangesForSeed();

            subCategoryItemStateDbSet.Add(new SubCategoryItemState() { StateName = "Eliminado" });
            MenuesSeedStart.SaveChangesForSeed();
        }
    }
}
