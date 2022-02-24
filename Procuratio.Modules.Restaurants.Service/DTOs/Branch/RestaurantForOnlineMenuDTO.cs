﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Restaurant.Service.DTOs.Branch
{
    public class RestaurantForOnlineMenuDTO
    {
        public int BranchId { get; set; }

        public string Name { get; set; }

        public string Slogan { get; set; }

        public string Adress { get; set; }

        public string Image { get; set; }
    }
}
