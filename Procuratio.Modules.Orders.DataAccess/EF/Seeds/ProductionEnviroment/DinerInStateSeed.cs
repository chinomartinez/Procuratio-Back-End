﻿using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class DinerInStateSeed
    {
        internal static void StartDinerInStateSeed(DbSet<DinerInState> dinerInStateDbSet)
        {
            if (dinerInStateDbSet.Any()) return;

            dinerInStateDbSet.Add(new DinerInState() { StateName = "Completada" });
            OrdersSeedStart.SaveChangesForSeed();

            dinerInStateDbSet.Add(new DinerInState() { StateName = "Eliminado" });
            OrdersSeedStart.SaveChangesForSeed();
        }
    }
}
