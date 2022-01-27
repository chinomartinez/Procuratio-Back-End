using System.Collections.Generic;

namespace Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs
{
    public class MenuDTO
    {
        public int MenuCategoryId { get; set; }

        public string MenuCategoryName { get; set; }

        public int MenuCategoryOrder { get; set; }

        public List<ItemForMenuDTO> ItemForMenuList { get; set; }
    }
}
