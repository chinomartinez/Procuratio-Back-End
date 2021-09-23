using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs
{
    public class WithoutReserveInProgressDTO
    {
        public WithoutReserveDTO WithoutReserve { get; set; }

        public string WaitersName { get; set; }

        public int OrderID { get; set; }

        public short OrderStateID { get; set; }

        public string OrderStateName { get; set; }

        public List<string> WithoutReserveTableNumbers { get; set; } = new List<string>();
    }
}
