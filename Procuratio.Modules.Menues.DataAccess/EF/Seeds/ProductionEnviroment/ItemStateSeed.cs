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

            itemStateDbSet.Add(new ItemState() { StateName = "Disponible" });
            MenuesSeedStart.SaveChangesForSeed();

            itemStateDbSet.Add(new ItemState() { StateName = "Eliminado" });
            MenuesSeedStart.SaveChangesForSeed();
        }
    }
}
