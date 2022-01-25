using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models
{
    public class OnlineMenuModel
    {
        public string MenuCategoryName { get; set; }

        public int CategoryOrder { get; set; }

        public List<ItemOnlineMenuModel> ItemsModel { get; set; }
    }
}
