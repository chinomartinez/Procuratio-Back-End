using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class UnitOfMeasureOfDrink : BaseEntity<int>
    {
        public string UnitOfMeasureOfDrinkName { get; set; }

        public List<ItemDrinkCapacity> ItemsDrinkCapacity { get; set; }
    }
}
