using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen
{
    public class OrderWithOrderDetailDTO
    {
        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public string Note { get; set; }
    }
}