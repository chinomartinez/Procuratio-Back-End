using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class ShoppingCartFromFormDTO
    {
        public List<ItemFromShoppingCartDTO> Items { get; set; }

        public string OrderKey { get; set; }
    }
}
