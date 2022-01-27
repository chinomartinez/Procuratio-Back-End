namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs
{
    public class ItemFromShoppingCartDTO
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public bool ForKitchen { get; set; }

        public string Comment { get; set; }
    }
}
