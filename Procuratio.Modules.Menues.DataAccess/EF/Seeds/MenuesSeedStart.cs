using Procuratio.Modules.Menu.DataAccess.EF.Seeds.Testing;
using Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment;

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
            MenuCategoryStateSeed.StartMenuCategoryStateSeed(menuesDbContext.MenuCategoryState);
            ItemStateSeed.StartItemStateSeed(menuesDbContext.ItemState);
        }

        private static void TestingSeeds(MenuDbContext menuesDbContext)
        {
            MenuCategorySeed.StartMenuCategorySeed(menuesDbContext.MenuCategory);
        }
    }
}
