using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities.intermediate
{
    public class TableXWithoutReserve : IntermediateBaseEntity
    {
        public int WithoutReserveID { get; set; }
        public WithoutReserve WithoutReserve { get; set; }

        public int TableID { get; set; }
        public Table Table { get; set; }
    }
}
