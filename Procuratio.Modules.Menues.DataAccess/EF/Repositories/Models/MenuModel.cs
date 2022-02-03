using System.Collections.Generic;

namespace Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models
{
    public class MenuModel
    {
        public int MenuCategoryId { get; set; }

        public string MenuCategoryName { get; set; }

        public int MenuCategoryOrder { get; set; }

        public List<ItemMenuModel> ItemsModel { get; set; }
    }
}
