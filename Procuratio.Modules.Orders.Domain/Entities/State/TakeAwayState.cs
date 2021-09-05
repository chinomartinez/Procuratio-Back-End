using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class TakeAwayState : StateBaseEntity<TakeAway>
    {
        public enum State : short
        {
            InProgress = 1,
            Completed,
            DidNotCome
        }
    }
}
