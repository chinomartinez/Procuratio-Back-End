using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities.intermediate
{
    public class TableXDinerIn : IntermediateBaseEntity
    {
        public int DinnerInID { get; set; }
        public DineIn DinnerIn { get; set; }
        public int TableID { get; set; }
        public Table Table { get; set; }
    }
}
