using System.Collections.Generic;

namespace Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs
{
    public class OnlineMenuDTO
    {
        public string MenuCategoryName { get; set; }

        public List<ItemForOnlineMenuDTO> itemForOnlineMenuList { get; set; }
    }
}
