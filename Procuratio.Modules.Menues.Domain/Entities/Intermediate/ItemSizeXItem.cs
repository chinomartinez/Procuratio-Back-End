using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Domain.Entities.Intermediate
{
    public class ItemSizeXItem : IntermediateBaseEntity
    {
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public int ItemSizeID { get; set; }
        public ItemSize ItemSize { get; set; }

        public decimal? PriceInsideRestaurant { get; set; }

        public decimal? PriceOutsideRestaurant { get; set; }

        public decimal? PromotionPriceInsideRestaurant { get; set; }

        public decimal? PromotionPriceOutsideRestaurant { get; set; }
    }
}
