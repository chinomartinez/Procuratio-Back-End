using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Cashes.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Seeds.ProductionEnviroment
{
    sealed class CashStateSeed : CashState
    {
        internal static void InitCashStateSeed(DbSet<CashState> cashStateDbSet)
        {
            if (cashStateDbSet.Any()) return;


        }
    }
}
