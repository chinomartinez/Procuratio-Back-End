using System.Collections.Generic;

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
