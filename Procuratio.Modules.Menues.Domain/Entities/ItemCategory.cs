using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class ItemCategory : BaseEntity<int>
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public short ItemCategoryStateId { get; set; }
        public ItemCategoryState ItemCategoryState { get; set; }

        public List<ItemSubCategory> ItemSubCategories { get; set; }
    }
}
