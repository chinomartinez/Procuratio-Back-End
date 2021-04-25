using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Menues.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class UnitOfMeasureOfDrinkSeed
    {
        internal static void StarUnitOfMeasureOfDrinkSeedSeed(DbSet<UnitOfMeasureOfDrink> unitOfMeasureOfDrinkSeedDbSet)
        {
            if (unitOfMeasureOfDrinkSeedDbSet.Any()) return;

            unitOfMeasureOfDrinkSeedDbSet.Add(new UnitOfMeasureOfDrink() { UnitOfMeasureOfDrinkName = "ml" });

            unitOfMeasureOfDrinkSeedDbSet.Add(new UnitOfMeasureOfDrink() { UnitOfMeasureOfDrinkName = "l" });
        }
    }
}
