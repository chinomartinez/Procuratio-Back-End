using Procuratio.Modules.Restaurants.DataAccess.EF.Seeds.ProductionEnviroment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurants.DataAccess.EF.Seeds
{
    internal static class RestaurantsSeedStart
    {
        internal static void CreateSeeds(RestaurantsDbContext restaurantsDbContext)
        {
            ProductionEnviromentSeeds(restaurantsDbContext);
            TestingSeeds(restaurantsDbContext);

            restaurantsDbContext.SaveChanges();
        }

        private static void ProductionEnviromentSeeds(RestaurantsDbContext restaurantsDbContext)
        {
            RestaurantSeed.StartRestaurantSeed(restaurantsDbContext.Restaurant);
        }

        private static void TestingSeeds(RestaurantsDbContext ordersDbContext)
        {
        }
    }
}
