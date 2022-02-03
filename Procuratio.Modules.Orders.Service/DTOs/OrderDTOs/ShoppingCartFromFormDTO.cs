using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class ShoppingCartFromFormDTO
    {
        public List<ItemFromShoppingCartDTO> Items { get; set; }

        public string OrderKey { get; set; }
    }
}
