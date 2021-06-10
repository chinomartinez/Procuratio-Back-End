using System.ComponentModel.DataAnnotations;

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
