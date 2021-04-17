using Procuratio.Modules.Cashes.DataAccess.EF.Seeds.ProductionEnviroment;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Seeds
{
    internal static class CashesSeedStart
    {
        private static CashesDbContext CashesDbContext;

        internal static void CreateSeeds(CashesDbContext cashesDbContext)
        {
            CashesDbContext = cashesDbContext;

            ProductionEnviromentSeeds();
            TestingSeeds();
        }

        private static void ProductionEnviromentSeeds()
        {
            CashStateSeed.StartCashStateSeed(CashesDbContext.CashState);
        }

        private static void TestingSeeds()
        {

            SaveChangesForSeed();
        }

        internal static void SaveChangesForSeed() => CashesDbContext.SaveChanges();
    }
}
