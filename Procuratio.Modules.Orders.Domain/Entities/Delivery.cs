using Procuratio.Modules.Orders.Domain.Entities.State;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "")]
namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class Delivery : BaseEntity<int>
    {
        public string DestinyDirection { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int DeliveryStateID { get; internal set; }
        public DeliveryState DeliveryState { get; set; }
    }
}
