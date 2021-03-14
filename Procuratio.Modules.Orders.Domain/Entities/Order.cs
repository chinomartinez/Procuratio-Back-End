using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Order
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        [StringLength(200, ErrorMessage = "La nota para la cocina no puede superar los 200 caracteres")]
        public string KitchenNote { get; set; }

        public int RestaurantID { get; set; }

        public int OrderStateID { get; set; }
        public OrderState OrderState { get; set; }

        public int ChefID { get; set; }
        //public User Chef { get; set; }

        public int CustomerID { get; set; }
        //public Customer Customer { get; set; }

        public Delivery Delivery { get; set; }

        public Reserve Reserve { get; set; }

        public TakeAway TakeAway { get; set; }

        public DinerIn DinerIn { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
