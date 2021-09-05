using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class TableState : StateBaseEntity<Table>
    {
        public enum State : short
        {
            Available = 1,
            Ocuped
        }
    }
}
