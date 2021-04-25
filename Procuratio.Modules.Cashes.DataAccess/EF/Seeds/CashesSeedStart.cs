using Procuratio.Modules.Cashes.DataAccess.EF.Seeds.ProductionEnviroment;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Seeds
{
    internal static class CashesSeedStart
    {
        internal static void CreateSeeds(CashesDbContext cashesDbContext)
        {
            ProductionEnviromentSeeds(cashesDbContext);
            TestingSeeds(cashesDbContext);

            cashesDbContext.SaveChanges();
        }

        private static void ProductionEnviromentSeeds(CashesDbContext cashesDbContext)
        {
            CashStateSeed.StartCashStateSeed(cashesDbContext.CashState);
        }

        private static void TestingSeeds(CashesDbContext cashesDbContext)
        {

        }
    }
}
