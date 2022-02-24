using Procuratio.Modules.Restaurant.Domain.Entities.intermediate;
using Procuratio.Modules.Restaurants.Domain.Entities;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Domain.Entities
{
    public class BranchSetting : BaseIdentity<int>
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int SettingId { get; set; }
        public Setting Setting { get; set; }

        public string UnconstrainedValue { get; set; }

        public enum Type
        {
            OnlineMenu = 1,
            OrderFromTable,
            ShowRestaurantInOnlineMenu
        }
    }
}
