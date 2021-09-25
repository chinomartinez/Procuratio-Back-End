using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class TakeAway : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public short TakeAwayStateId { get; set; }
        public TakeAwayState TakeAwayState { get; set; }
    }
}
