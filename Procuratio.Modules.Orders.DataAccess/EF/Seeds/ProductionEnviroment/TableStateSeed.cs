using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class TableStateSeed
    {
        internal static void StartTableStateSeed(DbSet<TableState> tableStateDbSet)
        {
            if (tableStateDbSet.Any()) return;

            tableStateDbSet.AddAsync(new TableState() { Id = (short)TableState.State.Available, StateName = "Disponible" });

            tableStateDbSet.AddAsync(new TableState() { Id = (short)TableState.State.Ocuped, StateName = "Ocupada" });
        }
    }
}
