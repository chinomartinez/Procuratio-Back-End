using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities.intermediate
{
    public class TableXWithoutReserve : IntermediateBaseEntity
    {
        public int WithoutReserveId { get; set; }
        public WithoutReserve WithoutReserve { get; set; }

        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
