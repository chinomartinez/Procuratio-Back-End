using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class TakeAwayState : StateBaseEntity
    {
        public List<TakeAway> TakeAways { get; set; }

        public enum State
        {
            InProgress = 1,
            Completed,
            DidNotCome
        }
    }
}
