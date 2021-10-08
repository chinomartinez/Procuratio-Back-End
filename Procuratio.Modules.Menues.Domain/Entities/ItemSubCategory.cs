using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class ItemSubCategory : BaseEntity<int>
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public List<Item> Items { get; set; }

        public short ItemSubCategoryStateId { get; set; }
        public ItemSubCategoryState ItemSubCategoryState { get; set; }

        public int ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }
    }
}
