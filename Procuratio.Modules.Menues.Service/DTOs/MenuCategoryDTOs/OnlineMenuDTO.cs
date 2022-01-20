using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs
{
    public class OnlineMenuDTO
    {
        public string MenuCategoryName { get; set; }

        public List<ItemForOnlineMenuDTO> itemForOnlineMenuList { get; set; }
    }
}
