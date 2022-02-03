using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs
{
    public class CustomerCredentialsDTO
    {
        [Required]
        public string Password { get; set; }
    }
}
