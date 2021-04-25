using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
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

        public int MyProperty { get; set; }

        public bool ForKitchen { get; set; }

        public string Image { get; set; }

        public int ItemOrder { get; set; }

        public int ItemStateID { get; internal set; }
        public ItemState ItemState { get; set; }

        public int? CategoryItemID { get; set; }
        public CategoryItem CategoryItem { get; set; }

        public int? SubCategoryItemID { get; set; }
        public SubCategoryItem SubCategoryItem { get; set; }

        public List<ExtraIngredientXItem> ExtrasIngredientsXItem { get; set; }


        public List<ItemXPromotion> ItemsXPromotions { get; set; }
    }
}
