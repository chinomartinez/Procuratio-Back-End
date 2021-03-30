using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class DinerIn : BaseEntity<int>
    {
        public int UserID { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int DinerInStateID { get; set; }
        public DinerInState DinerInState { get; set; }

        public List<TableXDinerIn> TableXDinerIn { get; set; }
    }
}
