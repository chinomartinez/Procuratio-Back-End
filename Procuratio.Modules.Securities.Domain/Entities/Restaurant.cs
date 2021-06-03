using Procuratio.Modules.Securities.Domain.Entities.MicrosoftIdentity;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;

namespace Procuratio.Modules.Securities.Domain.Entities
{
    public class Restaurant : ManualBaseIdentity<int>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Slogan { get; set; }

        public int? Withdrawn { get; set; }

        public DateTime? DateWithdrawn { get; set; }

        public List<User> Users { get; set; }

        public List<RestaurantPhone> RestaurantPhones { get; set; }
    }
}
