using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models
{
    public class MenuModel
    {
        public int MenuCategoryId { get; set; }

        public string MenuCategoryName { get; set; }

        public int MenuCategoryOrder { get; set; }

        public List<SubcategoryModel> SubcategoriesModel { get; set; }
    }
}
