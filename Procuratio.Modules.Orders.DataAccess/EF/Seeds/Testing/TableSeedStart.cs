using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Seeds.Testing
{
    internal class TableSeedStart
    {
        internal static void StartTableSeed(DbSet<Table> tableDbSet)
        {
            if (tableDbSet.IgnoreQueryFilters().Any()) return;

            tableDbSet.Add(new Table { BranchId = 1, Number = 1, TableStateId = (short)TableState.State.Available });
        }
    }
}
