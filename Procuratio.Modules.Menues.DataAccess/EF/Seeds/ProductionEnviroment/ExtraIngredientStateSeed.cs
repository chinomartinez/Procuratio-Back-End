using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class ExtraIngredientStateSeed
    {
        internal static void StartExtraIngredientStateSeed(DbSet<ExtraIngredientState> extraIngredientStateDbSet)
        {
            if (extraIngredientStateDbSet.Any()) return;

            extraIngredientStateDbSet.Add(new ExtraIngredientState() { StateName = "Disponible" });
            MenuesSeedStart.SaveChangesForSeed();

            extraIngredientStateDbSet.Add(new ExtraIngredientState() { StateName = "Eliminado" });
            MenuesSeedStart.SaveChangesForSeed();
        }
    }
}
