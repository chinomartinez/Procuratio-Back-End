using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class WithoutReserve : BaseEntity<int>
    {
        public int OrderID { get; set; }
        public Order Order { get; set; }

        public short WithoutReserveStateID { get; set; }
        public WithoutReserveState WithoutReserveState { get; set; }

        public List<TableXWithoutReserve> TableXWithoutReserve { get; set; }
    }
}
