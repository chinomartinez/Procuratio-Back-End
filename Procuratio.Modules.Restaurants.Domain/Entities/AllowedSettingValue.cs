using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Domain.Entities.intermediate
{
    public class AllowedSettingValue : ManualBaseIdentity<int>
    {
        public int SettingId { get; set; }
        public Setting Setting { get; set; }

        public string ItemValue { get; set; }

        public string Caption { get; set; }
    }
}
