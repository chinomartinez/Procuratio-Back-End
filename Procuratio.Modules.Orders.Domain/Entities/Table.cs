using Procuratio.Modules.Orders.Domain.Entities.intermediate;
using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Table : BaseEntity<int>
    {
        public short Number { get; set; }

        public int Capacity { get; set; }

        public List<TableXReserve> TableXReserve { get; set; }

        public List<TableXWithoutReserve> TableXWithoutReserve { get; set; }

        public short TableStateID { get; set; }
        public TableState TableState { get; set; }
    }
}
