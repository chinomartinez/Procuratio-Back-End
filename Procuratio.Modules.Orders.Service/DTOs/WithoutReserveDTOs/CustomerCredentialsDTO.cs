using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs
{
    public class CustomerCredentialsDTO
    {
        [Required]
        public string Password { get; set; }
    }
}
