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

            deliveryStateDbSet.AddRange(
                new DeliveryState() { Id = (short)DeliveryState.State.Completed, StateName = "Completado" },
                new DeliveryState() { Id = (short)DeliveryState.State.InProgress, StateName = "En curso" });
        }
    }
}
