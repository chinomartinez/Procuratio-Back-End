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

            orderStateDbSet.AddAsync(new OrderState() { ID = (short)OrderState.State.Pending, StateName = "Pendiente" });

            orderStateDbSet.AddAsync(new OrderState() { ID = (short)OrderState.State.InProgress, StateName = "En proceso" });

            orderStateDbSet.AddAsync(new OrderState() { ID = (short)OrderState.State.ForDelivery, StateName = "Para entrega" });

            orderStateDbSet.AddAsync(new OrderState() { ID = (short)OrderState.State.Delivered, StateName = "Entregado" });
        }
    }
}
