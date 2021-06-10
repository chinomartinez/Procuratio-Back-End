using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Restaurants.Domain.Entities;
using System.Linq;

namespace Procuratio.Modules.Restaurants.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class RestaurantSeed
    {
        internal static void StartRestaurantSeed(DbSet<Restaurant> restaurantDbSet)
        {
            if (restaurantDbSet.Any()) return;

            restaurantDbSet.Add(new Restaurant() { ID = 1, Name = "El DOMO", Slogan = "Experiencias sensoriales" });
        }
    }
}
