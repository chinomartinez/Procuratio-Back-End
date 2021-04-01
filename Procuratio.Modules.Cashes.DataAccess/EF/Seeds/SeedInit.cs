using Procuratio.Modules.Cashes.DataAccess.EF.Seeds.ProductionEnviroment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Seeds
{
    internal class SeedInit
    {
        internal static void CreateSeeds(CashesDbContext cashesDbContext)
        {
            CashStateSeed.InitCashStateSeed(cashesDbContext.CashStates);
        }
    }
}
