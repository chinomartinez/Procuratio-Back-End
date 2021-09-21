using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class WithoutReserveState : StateBaseEntity<WithoutReserve>
    {
        public enum State : short
        {
            Completed = 1,
            InProgress
        }
    }
}
