using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Procuratio.Modules.Restaurants.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class RestaurantSeed
    {
        internal static void StartRestaurantSeed(DbSet<Domain.Entities.Restaurant> restaurantDbSet)
        {
            if (restaurantDbSet.Any()) return;

            restaurantDbSet.Add(new Domain.Entities.Restaurant() { Id = 1, Name = "El DOMO", Slogan = "Experiencias sensoriales" });
        }
    }
}
