using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models
{
    public class SubcategoryModel
    {
        public int MenuSubcategoryId { get; set; }

        public string MenuSubcategoryName { get; set; }

        public int MenuSubcategoryOrder { get; set; }

        public List<ItemModel> ItemsModel { get; set; }
    }
}
