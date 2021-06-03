using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Securities.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal class UserStateSeed
    {
        internal static void StartUserStateSeed(DbSet<UserState> userStateDbSet)
        {
            if (userStateDbSet.Any()) return;

            userStateDbSet.Add(new UserState() { ID = (short)UserState.State.Active, StateName = "Activo" });

            userStateDbSet.Add(new UserState() { ID = (short)UserState.State.Withdrawn, StateName = "Dado de baja" });
        }
    }
}
