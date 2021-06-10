using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class DineIn : BaseEntity<int>
    {
        public int OrderID { get; set; }
        public Order Order { get; set; }

        public short DinerInStateID { get; set; }
        public DineInState DinerInState { get; set; }

        public List<TableXDinerIn> TableXDinerIn { get; set; }
    }
}
