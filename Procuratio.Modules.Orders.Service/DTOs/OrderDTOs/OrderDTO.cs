using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Orders.DTO.OrderDTOs
{
    public class OrderDTO : IDTO
    {
        [Required]
        public int ChefID { get; set; }

        [Required]
        public int WaiterID { get; set; }

        [Required]
        public int CustomerID { get; set; }
    }
}
