using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class TakeAway
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        public int UserID { get; set; }
        //public User User { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int TakeAwayStateID { get; set; }
        public TakeAwayState TakeAwayState { get; set; }
    }
}
