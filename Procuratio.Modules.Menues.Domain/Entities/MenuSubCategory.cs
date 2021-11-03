using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class MenuSubCategory : BaseEntity<int>
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public List<Item> Items { get; set; }

        public short MenuSubCategoryStateId { get; set; }
        public MenuSubCategoryState MenuSubCategoryState { get; set; }

        public int MenuCategoryId { get; set; }
        public MenuCategory MenuCategory { get; set; }
    }
}
