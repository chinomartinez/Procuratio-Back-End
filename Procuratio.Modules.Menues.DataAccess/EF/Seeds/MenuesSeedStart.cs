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
            ItemCategoryStateSeed.StartItemCategoryStateSeed(menuesDbContext.ItemCategoryState);
            ItemStateSeed.StartItemStateSeed(menuesDbContext.ItemState);
            ItemSubCategoryStateSeed.StartItemSubCategoryStateSeed(menuesDbContext.ItemSubCategoryState);
        }

        private static void TestingSeeds(MenuDbContext menuesDbContext)
        {
            ItemCategorySeed.StartItemCategorySeed(menuesDbContext.ItemCategory);
        }
    }
}
