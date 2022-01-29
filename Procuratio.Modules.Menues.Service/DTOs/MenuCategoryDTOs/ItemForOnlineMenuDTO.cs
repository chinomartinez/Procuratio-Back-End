namespace Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs
{
    public class ItemForOnlineMenuDTO
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string Description { get; set; }

        public bool ForKitchen { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
    }
}
