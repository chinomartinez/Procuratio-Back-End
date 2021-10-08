using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.DTOs.ItemDTOs
{
    public class MenuDTO
    {
        public int ItemCategoryId { get; set; }

        public string ItemCategoryName { get; set; }

        public int ItemSubCategoryId { get; set; }

        public string ItemSubCategoryName { get; set; }

        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public decimal? PriceInsideRestaurant { get; set; }

        public decimal? PriceOutsideRestaurant { get; set; }
    }
}
