using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Procuratio.Modules.Restaurants.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class RestaurantSeed
    {
        internal static void StartRestaurantSeed(DbSet<Domain.Entities.Restaurant> restaurantDbSet)
        {
            if (restaurantDbSet.Any()) return;

            restaurantDbSet.Add(new Domain.Entities.Restaurant() 
            {
                Id = 1, 
                Name = "El DOMO", 
                Slogan = "Experiencias sensoriales", 
                Image = string.Empty,
                Branches = new System.Collections.Generic.List<Domain.Entities.Branch>()
                {
                    new Domain.Entities.Branch()
                    {
                        Id = 1,
                        RestaurantId = 1,
                        Address = "Direccion falsa 5600",
                        Phone = "03034274171",
                        DateWithdrawn = null
                    }
                }
            });
        }
    }
}
