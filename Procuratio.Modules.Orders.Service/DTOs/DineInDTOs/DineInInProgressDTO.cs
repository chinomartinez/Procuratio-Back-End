using Procuratio.Modules.Orders.DTO.DinerInDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.DineInDTOs
{
    public class DineInInProgressDTO
    {
        public DineInDTO DineIn { get; set; }

        public string WaitersName { get; set; }

        public int OrderID { get; set; }

        public short OrderStateID { get; set; }

        public string OrderStateName { get; set; }

        public List<string> DineInTableNumbers { get; set; } = new List<string>();
    }
}
