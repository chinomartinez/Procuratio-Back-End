using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities.intermediate
{
    public class TableXReserve : IntermediateBaseEntity
    {
        public int ReserveID { get; set; }
        public Reserve Reserve { get; set; }
        public int TableID { get; set; }
        public Table Table { get; set; }
    }
}
