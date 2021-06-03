using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Domain.Entities
{
    public class RestaurantPhone : BaseIdentity<int>
    {
        public Restaurant Restaruant { get; set; }

        public string Phone { get; set; }
    }
}
