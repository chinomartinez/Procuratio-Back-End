using Procuratio.Modules.Order.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public DateTime Date { get; set; }

        public DateTime? WaitingTimeForKitchen { get; set; }

        public short OrderStateId { get; set; }
        public OrderState OrderState { get; set; }

        public int WaiterId { get; set; }

        public int CustomerId { get; set; }

        public Delivery Delivery { get; set; }

        public Reserve Reserve { get; set; }

        public TakeAway TakeAway { get; set; }

        public WithoutReserve WithoutReserve { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public List<TableXOrder> TableXOrders { get; set; }
    }
}
