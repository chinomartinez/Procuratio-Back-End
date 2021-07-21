using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class CategoryItem : BaseEntity<int>
    {
        public string Name { get; set; }

        public short CategoryItemStateID { get; set; }
        public CategoryItemState CategoryItemState { get; set; }

        public List<Item> Items { get; set; }

        public List<SubCategoryItem> SubCategoryItems { get; set; }
    }
}
