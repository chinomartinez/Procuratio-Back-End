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

            tableStateDbSet.Add(new TableState() { StateName = "Disponible" });
            OrdersSeedStart.SaveChangesForSeed();

            tableStateDbSet.Add(new TableState() { StateName = "Ocupada" });
            OrdersSeedStart.SaveChangesForSeed();

            tableStateDbSet.Add(new TableState() { StateName = "Eliminada" });
            OrdersSeedStart.SaveChangesForSeed();
        }
    }
}