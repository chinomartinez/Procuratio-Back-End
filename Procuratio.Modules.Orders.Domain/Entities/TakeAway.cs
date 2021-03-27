using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class TakeAway : BaseEntity<int>
    {
        public int UserID { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int TakeAwayStateID { get; set; }
        public TakeAwayState TakeAwayState { get; set; }
    }
}
