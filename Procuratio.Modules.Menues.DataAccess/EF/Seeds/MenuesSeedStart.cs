using Procuratio.Modules.Menues.DataAccess.EF.Seeds.ProductionEnviroment;

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
            ExtraIngredientStateSeed.StartExtraIngredientStateSeed(menuesDbContext.ExtraIngredientState);
            ExtraIngredientXItemStateSeed.StartExtraIngredientXItemStateSeed(menuesDbContext.ExtraIngredientXItemState);
            ItemStateSeed.StartItemStateSeed(menuesDbContext.ItemState);
            ItemXPromotionStateSeed.StartCategoryItemStateSeed(menuesDbContext.ItemXPromotionState);
            SubCategoryItemStateSeed.StartSubCategoryItemStateSeed(menuesDbContext.SubCategoryItemState);
            PromotionStateSeed.StartPromotionStateSeed(menuesDbContext.PromotionState);
            UnitOfMeasureOfDrinkSeed.StarUnitOfMeasureOfDrinkSeedSeed(menuesDbContext.UnitOfMeasureOfDrink);
        }

        private static void TestingSeeds(MenuesDbContext menuesDbContext)
        {
        }
    }
}
