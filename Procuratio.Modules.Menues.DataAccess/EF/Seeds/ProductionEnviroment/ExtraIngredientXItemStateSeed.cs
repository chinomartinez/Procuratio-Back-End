using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class ExtraIngredientXItemStateSeed
    {
        internal static void StartExtraIngredientXItemStateSeed(DbSet<ExtraIngredientXItemState> ExtraIngredientXItemStateDbSet)
        {
            if (ExtraIngredientXItemStateDbSet.Any()) return;

            ExtraIngredientXItemStateDbSet.Add(new ExtraIngredientXItemState() { StateName = "Disponible" });
            MenuesSeedStart.SaveChangesForSeed();

            ExtraIngredientXItemStateDbSet.Add(new ExtraIngredientXItemState() { StateName = "Eliminado" });
            MenuesSeedStart.SaveChangesForSeed();
        }
    }
}
