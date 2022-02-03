namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class ItemForOrderFormDTO
    {
        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public bool ForKitchen { get; set; }

        public string Comment { get; set; }
    }
}
