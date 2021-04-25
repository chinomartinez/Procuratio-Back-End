using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System.Linq;

namespace Procuratio.Modules.Orders.DataAccess.EF.Seeds.ProductionEnviroment
{
    internal static class OrderStateSeed
    {
        internal static void StartOrderStateSeed(DbSet<OrderState> orderStateDbSet)
        {
            if (orderStateDbSet.Any()) return;

            orderStateDbSet.Add(new OrderState() { ID = (int)OrderState.State.WithoutOrdering, StateName = "Sin Ordenar" });

            orderStateDbSet.Add(new OrderState() { ID = (int)OrderState.State.InProgress, StateName = "En proceso" });

            orderStateDbSet.Add(new OrderState() { ID = (int)OrderState.State.ForDelivery, StateName = "Para entrega" });

            orderStateDbSet.Add(new OrderState() { ID = (int)OrderState.State.Delivered, StateName = "Para entrega" });
        }
    }
}
