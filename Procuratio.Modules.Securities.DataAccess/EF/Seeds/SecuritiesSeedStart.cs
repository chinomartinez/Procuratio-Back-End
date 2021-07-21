using Procuratio.Modules.Securities.DataAccess.EF.Seeds.ProductionEnviroment;

namespace Procuratio.Modules.Securities.DataAccess.EF.Seeds
{
    internal static class SecuritiesSeedStart
    {
        internal static void CreateSeeds(SecurityDbContext securitiesDbContext)
        {
            ProductionEnviromentSeeds(securitiesDbContext);

            securitiesDbContext.SaveChanges();
        }

        private static void ProductionEnviromentSeeds(SecurityDbContext securitiesDbContext)
        {
            UserStateSeed.StartUserStateSeed(securitiesDbContext.UserState);
        }
    }
}
