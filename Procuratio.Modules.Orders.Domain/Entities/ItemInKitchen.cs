using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class ItemInKitchen : CompoundKeyBaseEntity<int>
    {
        public int OrderDetailID { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public int ItemID { get; set; }

        public int Quantity { get; set; }
    }
}
