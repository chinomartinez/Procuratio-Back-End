using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class Item : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool ForKitchen { get; set; }

        public string Image { get; set; }

        public int Order { get; set; }

        public decimal? PriceInsideRestaurant { get; set; }

        public decimal? PriceOutsideRestaurant { get; set; }

        public string Code { get; set; }

        public short ItemStateID { get; set; }
        public ItemState ItemState { get; set; }

        public int SubCategoryItemID { get; set; }
        public SubCategoryItem SubCategoryItem { get; set; }
    }
}
