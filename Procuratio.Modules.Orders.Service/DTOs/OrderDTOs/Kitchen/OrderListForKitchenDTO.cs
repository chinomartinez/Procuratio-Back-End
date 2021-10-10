using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen
{
    public class OrderListForKitchenDTO
    {
        public int OrderId { get; set; }

        public string WaitingTime { get; set; }

        public string WaitersName { get; set; }
    }
}
