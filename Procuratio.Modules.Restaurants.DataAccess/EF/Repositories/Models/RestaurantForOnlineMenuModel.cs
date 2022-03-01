using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Models
{
    public class RestaurantForOnlineMenuModel
    {
        public int BranchId { get; set; }

        public string Name { get; set; }

        public string Slogan { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }

        public string Phone { get; set; }

        public bool OnlineMenu { get; set; }
    }
}
