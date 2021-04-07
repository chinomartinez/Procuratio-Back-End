using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Domain.Entities
{
    public class Restaruant : BaseIdentity<int>
    {
        public string Name { get; set; }

        public int Withdrawn { get; set; }

        public DateTime DateWithdrawn { get; set; }
    }
}
