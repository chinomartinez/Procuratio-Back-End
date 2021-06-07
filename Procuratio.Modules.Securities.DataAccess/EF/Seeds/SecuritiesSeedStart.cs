using Procuratio.Modules.Securities.DataAccess.EF.Seeds.ProductionEnviroment;

namespace Procuratio.Modules.Securities.DataAccess.EF.Seeds
{
    internal static class SecuritiesSeedStart
    {
        internal static void CreateSeeds(SecuritiesDbContext securitiesDbContext)
        {
            ProductionEnviromentSeeds(securitiesDbContext);

            securitiesDbContext.SaveChanges();
        }

        private static void ProductionEnviromentSeeds(SecuritiesDbContext securitiesDbContext)
        {
            UserStateSeed.StartUserStateSeed(securitiesDbContext.UserState);
        }
    }
}
