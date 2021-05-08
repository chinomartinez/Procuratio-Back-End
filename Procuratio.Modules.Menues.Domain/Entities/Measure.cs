using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class Measure : ManualBaseIdentity<short>
    {
        public string MeasureName { get; set; }
    }
}
