﻿using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurants.Domain.Entities
{
    public class Branch : ManualBaseIdentity<int>
    {
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }

        public string Address { get; set; }

        public int? Withdrawn { get; set; }

        public DateTime? DateWithdrawn { get; set; }
    }
}