using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class ExtraIngredientXItemStateSeed
    {
        internal static void StartExtraIngredientXItemStateSeed(DbSet<ExtraIngredientXItemState> ExtraIngredientXItemStateDbSet)
        {
            if (ExtraIngredientXItemStateDbSet.Any()) return;

            ExtraIngredientXItemStateDbSet.Add(new ExtraIngredientXItemState() { ID = (int)ExtraIngredientXItemState.State.Available, StateName = "Disponible" });

            ExtraIngredientXItemStateDbSet.Add(new ExtraIngredientXItemState() { ID = (int)ExtraIngredientXItemState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
