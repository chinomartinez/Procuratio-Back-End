using System.Collections.Generic;

namespace Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models
{
    public class OnlineMenuModel
    {
        public string MenuCategoryName { get; set; }

        public int CategoryOrder { get; set; }

        public List<ItemOnlineMenuModel> ItemsModel { get; set; }
    }
}
