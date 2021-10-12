using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.OrderDetailDTOs
{
    public class OrderDetailForListItemsDTO
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool ForKitchen { get; set; }

        public string Image { get; set; }

        public decimal? PriceInsideRestaurant { get; set; }

        public decimal? PriceOutsideRestaurant { get; set; }

        public int Quantity { get; set; }

        public int QuantityInKitchen { get; set; }
    }
}
