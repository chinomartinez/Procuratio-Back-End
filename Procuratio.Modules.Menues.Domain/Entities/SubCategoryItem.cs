using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class SubCategoryItem : BaseEntity<int>
    {
        public string SubCategoryItemName { get; set; }

        public int SubCategoryItemOrder { get; set; }

        public List<Item> Items { get; set; }

        public short SubCategoryItemStateID { get; set; }
        public SubCategoryItemState SubCategoryItemState { get; set; }

        public int CategoryID { get; set; }
        public CategoryItem Category { get; set; }
    }
}
