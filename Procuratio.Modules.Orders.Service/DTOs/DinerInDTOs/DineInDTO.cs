using Procuratio.Modules.Orders.DTO.OrderDTOs;
using Procuratio.Modules.Orders.DTO.TableXDinerInDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DTO.DinerInDTOs
{
    public class DineInDTO
    {
        public int OrderID { get; set; }
        public OrderDTO Order { get; set; }

        public short DinerInStateID { get; set; }

        public List<TableXDinerInDTO> TableXDinerIn { get; set; }
    }
}
