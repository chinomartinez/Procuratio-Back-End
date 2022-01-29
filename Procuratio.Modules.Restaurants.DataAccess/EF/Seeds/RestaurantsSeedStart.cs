using Procuratio.Modules.Restaurant.DataAccess.EF.Seeds.ProductionEnviroment;
using Procuratio.Modules.Restaurants.DataAccess.EF.Seeds.ProductionEnviroment;

namespace Procuratio.Modules.Restaurants.DataAccess.EF.Seeds
{
    internal static class RestaurantsSeedStart
    {
        internal static void CreateSeeds(RestaurantDbContext restaurantsDbContext)
        {
            ProductionEnviromentSeeds(restaurantsDbContext);
            TestingSeeds(restaurantsDbContext);
        }

        private static void ProductionEnviromentSeeds(RestaurantDbContext restaurantsDbContext)
        {
            SettingSeed.StartSettingSeed(restaurantsDbContext.Setting);
            restaurantsDbContext.SaveChanges();
        }

        private static void TestingSeeds(RestaurantDbContext restaurantsDbContext)
        {
            RestaurantSeed.StartRestaurantSeed(restaurantsDbContext.Restaurant);
            restaurantsDbContext.SaveChanges();
        }
    }
}
