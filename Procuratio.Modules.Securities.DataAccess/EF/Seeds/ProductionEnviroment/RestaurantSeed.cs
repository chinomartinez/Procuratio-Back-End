using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Securities.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class RestaurantSeed
    {
        internal static void StartRestaurantSeed(DbSet<Restaruant> restaurantDbSet)
        {
            if (restaurantDbSet.Any()) return;

            restaurantDbSet.Add(new Restaruant() { ID = 1, Name = "El DOMO", Address = "Sta Fe 222-298", Slogan = "Experiencias sensoriales" });
        }
    }
}
