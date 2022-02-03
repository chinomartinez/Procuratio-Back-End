using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class OrderDetail : BaseEntity<int>
    {
        public int Quantity { get; set; }

        public int QuantityInKitchen { get; set; }

        public int ItemId { get; set; }

        public string Comment { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
