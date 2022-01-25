using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class ItemFromShoppingCartDTO
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public bool ForKitchen { get; set; }

        public string Comment { get; set; }
    }
}
