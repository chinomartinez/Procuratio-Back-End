using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Runtime.CompilerServices;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class TakeAway : BaseEntity<int>
    {
        public int OrderID { get; set; }
        public Order Order { get; set; }

        public short TakeAwayStateID { get; set; }
        public TakeAwayState TakeAwayState { get; set; }
    }
}
