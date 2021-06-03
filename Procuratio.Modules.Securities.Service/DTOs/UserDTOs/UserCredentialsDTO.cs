﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Securities.Service.DTOs.UserDTOs
{
    public class UserCredentialsDTO
    {
        [Required]
        public string RestaurantName { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public int RestaurantID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
