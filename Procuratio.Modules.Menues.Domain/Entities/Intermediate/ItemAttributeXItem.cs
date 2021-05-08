using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Domain.Entities.Intermediate
{
    public class ItemAttributeXItem : IntermediateBaseEntity
    {
        public int ItemAttributeID { get; set; }
        public ItemAttribute ItemAttribute { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }

        public decimal? PriceInsideRestaurant { get; set; }

        public decimal? PriceOutsideRestaurant { get; set; }
    }
}
