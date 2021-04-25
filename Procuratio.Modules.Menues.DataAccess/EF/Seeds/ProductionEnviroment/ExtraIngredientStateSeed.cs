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

            extraIngredientStateDbSet.Add(new ExtraIngredientState() { ID = (int)ExtraIngredientState.State.Available, StateName = "Disponible" });

            extraIngredientStateDbSet.Add(new ExtraIngredientState() { ID = (int)ExtraIngredientState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
