
namespace Procuratio.Modules.Securities.DataAccess.EF.Seeds
{
    internal static class SecuritiesSeedStart
    {
        internal static void CreateSeeds(SecurityDbContext securitiesDbContext)
        {
            ProductionEnviromentSeeds(securitiesDbContext);
            TestingSeeds(securitiesDbContext);
        }

        private static void ProductionEnviromentSeeds(SecurityDbContext securitiesDbContext)
        {
            securitiesDbContext.SaveChanges();
        }

        private static void TestingSeeds(SecurityDbContext securitiesDbContext)
        {
            securitiesDbContext.SaveChanges();
        }
    }
}
