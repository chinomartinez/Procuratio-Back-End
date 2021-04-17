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

            customerXOrderStateSeedDbSet.Add(new CustomerXOrderState() { StateName = "Disponible" });
            CustomersSeedStart.SaveChangesForSeed();

            customerXOrderStateSeedDbSet.Add(new CustomerXOrderState() { StateName = "Usado" });
            CustomersSeedStart.SaveChangesForSeed();

            customerXOrderStateSeedDbSet.Add(new CustomerXOrderState() { StateName = "Eliminado" });
            CustomersSeedStart.SaveChangesForSeed();
        }
    }
}
