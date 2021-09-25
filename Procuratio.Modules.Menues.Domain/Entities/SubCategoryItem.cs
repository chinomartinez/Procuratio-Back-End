using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class SubCategoryItem : BaseEntity<int>
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public List<Item> Items { get; set; }

        public short SubCategoryItemStateId { get; set; }
        public SubCategoryItemState SubCategoryItemState { get; set; }

        public int CategoryId { get; set; }
        public CategoryItem Category { get; set; }
    }
}
