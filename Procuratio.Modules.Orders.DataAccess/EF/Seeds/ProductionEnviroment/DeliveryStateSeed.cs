using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class DeliveryStateSeed
    {
        internal static void StartDeliveryStateSeed(DbSet<DeliveryState> deliveryStateDbSet)
        {
            if (deliveryStateDbSet.Any()) return;

            deliveryStateDbSet.Add(new DeliveryState() { StateName = "Completado" });
            OrdersSeedStart.SaveChangesForSeed();

            deliveryStateDbSet.Add(new DeliveryState() { StateName = "Eliminado" });
            OrdersSeedStart.SaveChangesForSeed();

            deliveryStateDbSet.Add(new DeliveryState() { StateName = "No entregado" });
            OrdersSeedStart.SaveChangesForSeed();
        }
    }
}
