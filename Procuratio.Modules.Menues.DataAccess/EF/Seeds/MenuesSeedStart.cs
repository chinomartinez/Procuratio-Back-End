using Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.DataAccess.EF.Seeds
{
    internal static class MenuesSeedStart
    {
        private static MenuesDbContext MenuesDbContext;

        internal static void CreateSeeds(MenuesDbContext menuesDbContext)
        {
            MenuesDbContext = menuesDbContext;

            ProductionEnviromentSeeds();
            TestingSeeds();

            menuesDbContext.SaveChanges();
        }

        private static void ProductionEnviromentSeeds()
        {
            CategoryItemStateSeed.StartCategoryItemStateSeed(MenuesDbContext.CategoryItemState);
            ExtraIngredientStateSeed.StartExtraIngredientStateSeed(MenuesDbContext.ExtraIngredientState);
            ExtraIngredientXItemStateSeed.StartExtraIngredientXItemStateSeed(MenuesDbContext.ExtraIngredientXItemState);
            ItemStateSeed.StartItemStateSeed(MenuesDbContext.ItemState);
            ItemXPromotionStateSeed.StartCategoryItemStateSeed(MenuesDbContext.ItemXPromotionState);
            SubCategoryItemStateSeed.StartCategoryItemStateSeed(MenuesDbContext.SubCategoryItemState);
            PromotionStateSeed.StartPromotionStateSeed(MenuesDbContext.PromotionState);
        }

        private static void TestingSeeds()
        {
            SaveChangesForSeed();
        }

        internal static void SaveChangesForSeed() => MenuesDbContext.SaveChanges();
    }
}
