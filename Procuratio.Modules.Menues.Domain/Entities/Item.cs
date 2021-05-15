using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "")]
namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class Item : BaseEntity<int>
    {
        public string ItemName { get; set; }

        public string Description { get; set; }

        public bool ForKitchen { get; set; }

        public string Image { get; set; }

        public int ItemOrder { get; set; }

        public decimal? PriceInsideRestaurant { get; set; }

        public decimal? PriceOutsideRestaurant { get; set; }

        public string Code { get; set; }

        public short ItemStateID { get; internal set; }
        public ItemState ItemState { get; set; }

        public int? CategoryItemID { get; set; }
        public CategoryItem CategoryItem { get; set; }

        public int? SubCategoryItemID { get; set; }
        public SubCategoryItem SubCategoryItem { get; set; }
    }
}
