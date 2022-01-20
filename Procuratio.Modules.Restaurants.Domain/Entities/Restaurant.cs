using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System.Collections.Generic;

namespace Procuratio.Modules.Restaurants.Domain.Entities
{
    public class Restaurant : ManualBaseIdentity<int>
    {
        public string Name { get; set; }

        public string Slogan { get; set; }

        public string Image { get; set; }

        public List<Branch> Branches { get; set; }
    }
}
