using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities.State
{
    public class TableState : StateBaseEntity
    {
        public List<Table> Table { get; set; }

        public enum State : short
        {
            Available = 1,
            Ocuped,
            Deleted
        }
    }
}
