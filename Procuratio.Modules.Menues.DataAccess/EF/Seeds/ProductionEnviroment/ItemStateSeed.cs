using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class ItemStateSeed
    {
        internal static void StartItemStateSeed(DbSet<ItemState> itemStateDbSet)
        {
            if (itemStateDbSet.Any()) return;

            itemStateDbSet.Add(new ItemState() { Id = (short)ItemState.State.Available, StateName = "Disponible" });

            itemStateDbSet.Add(new ItemState() { Id = (short)ItemState.State.Deleted, StateName = "Eliminado" });
        }
    }
}
