using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class MeasureSeed
    {
        internal static void StartItemStateSeed(DbSet<Measure> measureDbSet)
        {
            if (measureDbSet.Any()) return;

            measureDbSet.Add(new Measure() { ID = 1, MeasureName = "ml" });

            measureDbSet.Add(new Measure() { ID = 2, MeasureName = "l" });

            measureDbSet.Add(new Measure() { ID = 3, MeasureName = "cc" });
        }
    }
}
