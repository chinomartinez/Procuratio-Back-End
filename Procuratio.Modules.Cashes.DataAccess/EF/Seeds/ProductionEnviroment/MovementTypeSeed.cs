using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Cashes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal class MovementTypeSeed
    {
        internal static void StartCashStateSeed(DbSet<MovementType> cashStateDbSet)
        {
            if (cashStateDbSet.Any()) return;

            cashStateDbSet.Add(new MovementType() { ID = (int)MovementType.Type.Income, Name = "Ingreso" });

            cashStateDbSet.Add(new MovementType() { ID = (int)MovementType.Type.Expenditure, Name = "Egreso" });
        }
    }
}
