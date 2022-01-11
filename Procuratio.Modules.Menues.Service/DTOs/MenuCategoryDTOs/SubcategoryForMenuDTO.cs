using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs
{
    public class SubcategoryForMenuDTO
    {
        public int MenuSubcategoryId { get; set; }

        public string MenuSubcategoryName { get; set; }

        public int MenuSubcategoryOrder { get; set; }

        public List<ItemForMenuDTO> ItemForMenuList { get; set; }
    }
}
