namespace Procuratio.Modules.Order.Service.DTOs.OrderDetailDTOs
{
    public class OrderDetailForListItemsDTO
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool ForKitchen { get; set; }

        public string Comment { get; set; }

        public int Quantity { get; set; }

        public int QuantityInKitchen { get; set; }
    }
}
