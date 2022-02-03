using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Repositories.Models
{
    public class SettingsModel
    {
        public int SettingId { get; set; }

        public int BranchId { get; set; }

        public string Description { get; set; }

        public string DataType { get; set; }

        public string Value { get; set; }

        public string Caption { get; set; }

        public int? MinValue { get; set; }

        public int? MaxValue { get; set; }
    }
}
