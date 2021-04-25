using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class TableState : StateBaseEntity
    {
        public List<Table> Table { get; set; }

        public enum State
        {
            Available = 1,
            Ocuped,
            Deleted
        }
    }
}
