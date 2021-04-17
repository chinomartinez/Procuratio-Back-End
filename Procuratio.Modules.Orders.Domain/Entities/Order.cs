﻿using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "")]
namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public DateTime Date { get; set; }

        public string KitchenNote { get; set; }

        public int OrderStateID { get; internal set; }
        public OrderState OrderState { get; set; }

        public int ChefID { get; set; }

        public int WaiterID { get; set; }

        public int CustomerID { get; set; }

        public Delivery Delivery { get; set; }

        public Reserve Reserve { get; set; }

        public TakeAway TakeAway { get; set; }

        public DinerIn DinerIn { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
