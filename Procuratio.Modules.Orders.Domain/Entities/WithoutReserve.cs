using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class WithoutReserve : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public short WithoutReserveStateId { get; set; }
        public WithoutReserveState WithoutReserveState { get; set; }
    }
}
