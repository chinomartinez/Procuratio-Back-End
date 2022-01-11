using Microsoft.AspNetCore.Mvc;
using Procuratio.ProcuratioFramework.ProcuratioFramework.ModelBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs
{
    public class MenuDTO
    {
        public int MenuCategoryId { get; set; }

        public string MenuCategoryName { get; set; }

        public int MenuCategoryOrder { get; set; }

        public List<SubcategoryForMenuDTO> SubcategoryForMenuList { get; set; }
    }
}
