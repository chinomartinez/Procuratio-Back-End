using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Orders.Service.DTOs.TableDTOs
{
    public class AddTableDTO
    {
        [Required]
        public int Capacity { get; set; }
    }
}
