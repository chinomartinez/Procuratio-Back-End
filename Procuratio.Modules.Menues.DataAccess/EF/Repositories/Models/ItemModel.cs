using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menu.DataAccess.EF.Repositories.Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int ItemOrder { get; set; }
    }
}
