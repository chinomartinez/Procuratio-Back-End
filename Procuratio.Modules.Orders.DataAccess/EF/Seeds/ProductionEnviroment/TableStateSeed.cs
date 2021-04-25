﻿using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class TableStateSeed
    {
        internal static void StartTableStateSeed(DbSet<TableState> tableStateDbSet)
        {
            if (tableStateDbSet.Any()) return;

            tableStateDbSet.Add(new TableState() { ID = (int)TableState.State.Available, StateName = "Disponible" });

            tableStateDbSet.Add(new TableState() { ID = (int)TableState.State.Ocuped, StateName = "Ocupada" });

            tableStateDbSet.Add(new TableState() { ID = (int)TableState.State.Deleted, StateName = "Eliminada" });
        }
    }
}
