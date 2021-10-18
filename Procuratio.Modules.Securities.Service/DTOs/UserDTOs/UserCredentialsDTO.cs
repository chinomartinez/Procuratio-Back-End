using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Securities.Service.DTOs.UserDTOs
{
    public class UserCredentialsDTO
    {
        [Required]
        public string User { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
