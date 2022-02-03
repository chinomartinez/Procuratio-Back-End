using Procuratio.Modules.Menu.DataAccess.EF.Seeds.Testing;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds
{
    internal static class MenuesSeedStart
    {
        internal static void CreateSeeds(MenuDbContext menuesDbContext)
        {
            ProductionEnviromentSeeds(menuesDbContext);

            menuesDbContext.SaveChanges();

            TestingSeeds(menuesDbContext);

            menuesDbContext.SaveChanges();
        }

        private static void ProductionEnviromentSeeds(MenuDbContext menuesDbContext)
        {
        }

        private static void TestingSeeds(MenuDbContext menuesDbContext)
        {
            MenuCategorySeed.StartMenuCategorySeed(menuesDbContext.MenuCategory);
        }
    }
}
