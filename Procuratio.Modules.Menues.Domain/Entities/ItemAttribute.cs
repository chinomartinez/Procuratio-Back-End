using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Menues.Domain.Entities
{
    public class ItemAttribute : BaseEntity<int>
    {
        public string Attribute { get; set; }

        public short? MeasureID { get; set; }
        public Measure Measure { get; set; }
    }
}
