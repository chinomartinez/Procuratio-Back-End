using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;

namespace Procuratio.Modules.Restaurants.Domain.Entities
{
    public class Branch : ManualBaseIdentity<int>
    {
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public string Address { get; set; }

        public int? Withdrawn { get; set; }

        public DateTime? DateWithdrawn { get; set; }
    }
}
