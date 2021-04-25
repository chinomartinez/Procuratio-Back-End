using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Customers.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Customers.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class CustomerXOrderStateSeed
    {
        internal static void StartCashStateSeed(DbSet<CustomerXOrderState> customerXOrderStateSeedDbSet)
        {
            if (customerXOrderStateSeedDbSet.Any()) return;

            customerXOrderStateSeedDbSet.Add(new CustomerXOrderState() { ID = (int)CustomerXOrderState.State.Available, StateName = "Disponible" });

            customerXOrderStateSeedDbSet.Add(new CustomerXOrderState() { ID = (int)CustomerXOrderState.State.Used, StateName = "Usado" });

            customerXOrderStateSeedDbSet.Add(new CustomerXOrderState() { ID = (int)CustomerXOrderState.State.Deleted, StateName = "Eliminado" });
        }
    }
}