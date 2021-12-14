using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class OrderInProgressDTO
    {
        public string WaitersName { get; set; }

        public int OrderId { get; set; }

        public short OrderStateId { get; set; }

        public string OrderStateName { get; set; }

        public List<string> OrderTableNumbers { get; set; } = new List<string>();
    }
}
