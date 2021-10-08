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

            orderStateDbSet.AddRange(
                new OrderState() { Id = (short)OrderState.State.Pending, StateName = "Pendiente" },
                new OrderState() { Id = (short)OrderState.State.InProgress, StateName = "En proceso" },
                new OrderState() { Id = (short)OrderState.State.ForDelivery, StateName = "Para entrega" },
                new OrderState() { Id = (short)OrderState.State.Delivered, StateName = "Entregado" });
        }
    }
}
