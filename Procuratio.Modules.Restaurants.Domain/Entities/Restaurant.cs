using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurants.Domain.Entities
{
    public class Restaurant : ManualBaseIdentity<int>
    {
        public string Name { get; set; }

        public string Slogan { get; set; }

        public List<Branch> Branches { get; set; }
    }
}
