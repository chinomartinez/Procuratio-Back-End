using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Domain.Entities.intermediate
{
    public class TableXReserve
    {
        public int ReserveID { get; set; }
        public Reserve Reserve { get; set; }
        public int TableID { get; set; }
        public Table Table { get; set; }
        public int RestaurantID { get; set; }
    }
}
