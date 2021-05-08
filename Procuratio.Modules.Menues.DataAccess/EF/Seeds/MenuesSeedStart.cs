﻿using Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds
{
    internal static class MenuesSeedStart
    {
        internal static void CreateSeeds(MenuesDbContext menuesDbContext)
        {
            ProductionEnviromentSeeds(menuesDbContext);
            TestingSeeds(menuesDbContext);

            menuesDbContext.SaveChanges();
        }

        private static void ProductionEnviromentSeeds(MenuesDbContext menuesDbContext)
        {
            CategoryItemStateSeed.StartCategoryItemStateSeed(menuesDbContext.CategoryItemState);
            ItemStateSeed.StartItemStateSeed(menuesDbContext.ItemState);
            SubCategoryItemStateSeed.StartSubCategoryItemStateSeed(menuesDbContext.SubCategoryItemState);
        }

        private static void TestingSeeds(MenuesDbContext menuesDbContext)
        {
        }
    }
}
