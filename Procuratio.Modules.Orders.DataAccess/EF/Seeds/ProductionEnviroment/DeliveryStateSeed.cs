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

            deliveryStateDbSet.Add(new DeliveryState() { ID = (int)DeliveryState.State.Completado, StateName = "Completado" });

            deliveryStateDbSet.Add(new DeliveryState() { ID = (int)DeliveryState.State.EnCurso, StateName = "En curso" });
        }
    }
}
