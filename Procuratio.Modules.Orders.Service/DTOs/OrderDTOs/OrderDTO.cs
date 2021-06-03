using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Orders.DTO.OrderDTOs
{
    public class OrderDTO
    {
        [Required]
        public int ChefID { get; set; }

        [Required]
        public int WaiterID { get; set; }

        [Required]
        public int CustomerID { get; set; }
    }
}
