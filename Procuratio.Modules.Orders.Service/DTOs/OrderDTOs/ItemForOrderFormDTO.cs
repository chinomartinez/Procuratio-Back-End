using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class ItemForOrderFormDTO
    {
        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public bool ForKitchen { get; set; }

        public string Note { get; set; }
    }
}
