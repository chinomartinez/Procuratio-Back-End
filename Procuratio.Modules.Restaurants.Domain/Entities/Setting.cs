using Procuratio.Modules.Restaurant.Domain.Entities.intermediate;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Domain.Entities
{
    public class Setting : ManualBaseIdentity<int>
    {
        public string Description { get; set; }

        public bool Constrained { get; set; }

        public string DataType { get; set; }

        public int? MinValue { get; set; }

        public int? MaxValue { get; set; }

        public List<AllowedSettingValue> AllowedSettingValues { get; set; }

        public List<BranchSetting> BranchSetting { get; set; }

        public enum Type : short
        {
            OnlineMenu = 1,
            OrderFromTable
        }
    }
}
