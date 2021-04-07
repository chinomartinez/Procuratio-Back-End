using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Cashes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Seeds.Testing
{
    internal class MountTypeSeed
    {
        internal static void StartCashStateSeed(DbSet<MountType> mountTypeDbSet)
        {
            if (mountTypeDbSet.Any()) return;

            // Adding...
        }
    }
}
