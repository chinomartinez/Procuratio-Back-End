using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Delivery : BaseEntity<int>
    {
        public string DestinyDirection { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public short DeliveryStateId { get; set; }
        public DeliveryState DeliveryState { get; set; }
    }
}
