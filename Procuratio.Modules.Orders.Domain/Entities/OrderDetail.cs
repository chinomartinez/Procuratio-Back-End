using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class OrderDetail : BaseEntity<int>
    {
        public int Quantity { get; set; }

        public int QuantityInKitchen { get; set; }

        public int ItemID { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
