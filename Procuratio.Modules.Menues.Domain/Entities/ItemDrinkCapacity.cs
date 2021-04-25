using Procuratio.Modules.Menues.Domain.Entities.Intermediate;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class ItemDrinkCapacity : BaseEntity<int>
    {
        public int DrinkCapacity { get; set; }

        public List<ItemDrinkCapacityXItem> ItemsDrinkCapacityXItem { get; set; }

        public UnitOfMeasureOfDrink UnitOfMeasureOfDrink { get; set; }
    }
}
