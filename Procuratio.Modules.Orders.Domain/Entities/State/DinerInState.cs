using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class DinerInState : StateBaseEntity
    {
        public List<DinerIn> DinerIn { get; set; }

        public enum State
        {
            Completed = 1,
            InProgress
        }
    }
}
