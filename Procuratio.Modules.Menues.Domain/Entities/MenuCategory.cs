using Procuratio.Modules.Menues.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class MenuCategory : BaseEntity<int>
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public short MenuCategoryStateId { get; set; }
        public MenuCategoryState MenuCategoryState { get; set; }

        public List<Item> Items { get; set; }
    }
}
