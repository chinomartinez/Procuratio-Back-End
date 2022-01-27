using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Service.DTOs.Branch
{
    public class SettingsDTO
    {
        public int SettingId { get; set; }

        public string Description { get; set; }

        public string DataType { get; set; }

        public string Value { get; set; }

        public string Caption { get; set; }

        public int? MinValue { get; set; }

        public int? MaxValue { get; set; }
    }
}
