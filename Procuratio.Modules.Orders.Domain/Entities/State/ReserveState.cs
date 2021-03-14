using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class ReserveState
    {
        public int ID { get; set; }

        public int RestaurantID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public List<Reserve> Reserve { get; set; }
    }
}
