using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;

namespace Procuratio.Modules.Restaurants.Domain.Entities
{
    public class Branch : ManualBaseIdentity<int>
    {
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Instagram { get; set; }

        public string Location { get; set; } // cambiar al tipo point de NetTopologySuite.Geometries

        public DateTime? DateWithdrawn { get; set; }
    }
}
