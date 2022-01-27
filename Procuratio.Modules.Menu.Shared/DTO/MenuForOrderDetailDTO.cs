namespace Procuratio.Modules.Menu.Shared.DTO
{
    public class MenuForOrderDetailDTO
    {
        public int ItemId { get; set; }

        public bool ForKitchen { get; set; }

        public string ItemName { get; internal set; }

        public decimal Price { get; internal set; }
    }
}
