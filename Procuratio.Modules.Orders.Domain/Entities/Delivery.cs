using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Delivery : BaseEntity<int>
    {
        public string DestinyDirection { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public short DeliveryStateID { get; set; }
        public DeliveryState DeliveryState { get; set; }
    }
}
