using Procuratio.Modules.Orders.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Order.Domain.Entities.intermediate
{
    public class TableXOrder : IntermediateBaseEntity
    {
        public int OrderId { get; set; }
        public Orders.Domain.Entities.Order Order { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
