namespace Procuratio.Modules.Order.Service.DTOs.OrderDTOs.Kitchen
{
    public class OrderWithOrderDetailVM
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public string Comment { get; set; }

        public int Quantity { get; set; }
    }
}
