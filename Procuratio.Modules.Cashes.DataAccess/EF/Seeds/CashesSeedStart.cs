using Procuratio.Modules.Cashes.DataAccess.EF.Seeds.ProductionEnviroment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
