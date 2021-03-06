namespace Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models
{
    public class ItemOnlineMenuModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public string Description { get; set; }

        public bool ForKitchen { get; set; }

        public int ItemOrder { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
    }
}
