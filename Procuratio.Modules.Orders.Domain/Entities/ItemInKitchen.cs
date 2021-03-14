using Procuratio.ProcuratioFramework.ProcuratioFramework.CustomsDataAnnotationValidations.NumersValidation;

namespace Procuratio.Modules.Orders.Domain.Entities
{
    public class ItemInKitchen
    {
        public int OrderDetailID { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public int ItemID { get; set; }

        public int RestaurantID { get; set; }

        [GreaterThanZero]
        public int Quantity { get; set; }
    }
}
