using Microsoft.EntityFrameworkCore;
using Procuratio.Modules.Order.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.DataAccess.EF.Seeds.Testing
{
    internal class WithoutReserveSeedStart
    {
        internal static void StartWithoutReserveSeed(DbSet<WithoutReserve> withoutReserveDbSet)
        {
            if (withoutReserveDbSet.IgnoreQueryFilters().Any()) return;

            for (int i = 0; i < 500; i++)
            {
                Orders.Domain.Entities.Order order = new()
                {
                    OrderStateId = (short)OrderState.State.Paid,
                    WaiterId = 1,
                    CustomerId = 1,
                    WaitingTimeForKitchen = null,
                    BranchId = 1,
                    OrderDetails = new(),
                    TableXOrders = new()
                    {
                        new TableXOrder()
                        {
                            TableId = 1,
                            BranchId = 1
                        }
                    }
                };

                Random rand = new();

                order.Date = new DateTime(rand.Next(2014, 2023), rand.Next(1, 13), rand.Next(1, 29), 0, 0, 0);

                for (int j = 0; j < 10; j++)
                {
                    int currentItemId = 0;

                    do
                    {
                        currentItemId = rand.Next(1, 156);

                    } while (order.OrderDetails.Any(x => x.ItemId == currentItemId));

                    OrderDetail detail = new()
                    {
                        Quantity = rand.Next(1, 6),
                        QuantityInKitchen = 0,
                        Comment = string.Empty,
                        ItemId = currentItemId,
                        BranchId = 1
                    };

                    order.OrderDetails.Add(detail);
                }

                WithoutReserve withoutReserve = new()
                {
                    WithoutReserveStateId = (short)WithoutReserveState.State.Completed,
                    Password = string.Empty,
                    BranchId = 1,
                    Order = order
                };

                withoutReserveDbSet.Add(withoutReserve);
            }
        }
    }
}
