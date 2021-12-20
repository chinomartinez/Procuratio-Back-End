using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Securities.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Securities.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal class UserStateSeed
    {
        internal static void StartUserStateSeed(DbSet<UserState> userStateDbSet)
        {
            if (userStateDbSet.Any()) return;

            userStateDbSet.Add(new UserState() { Id = (short)UserState.State.Active, StateName = "Activo" });

            userStateDbSet.Add(new UserState() { Id = (short)UserState.State.Withdrawn, StateName = "Dado de baja" });
        }
    }
}
