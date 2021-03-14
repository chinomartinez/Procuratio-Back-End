using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class DinerIn
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        public int UserID { get; set; }
        //public User User { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int DinerInStateID { get; set; }
        public DinerInState DinerInState { get; set; }

        public List<TableXDinerIn> TableXDinerIn { get; set; }
    }
}
