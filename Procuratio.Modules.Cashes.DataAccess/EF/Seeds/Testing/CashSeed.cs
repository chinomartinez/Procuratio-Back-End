using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Cashes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Seeds.Testing
{
    internal class CashSeed
    {
        internal static void StartCasheed(DbSet<Cash> cashDbSet)
        {
            if (cashDbSet.Any()) return;

            // Adding...
        }
    }
}
