using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class ReserveState : StateBaseEntity
    {
        public List<Reserve> Reserve { get; set; }

        public enum State
        {
            Pending = 1,
            Unconfirmed,
            InProgress,
            Completed,
            DidNotCome
        }
    }
}
