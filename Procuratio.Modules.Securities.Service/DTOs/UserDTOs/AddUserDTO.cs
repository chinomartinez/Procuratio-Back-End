using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Securities.Service.DTOs.UserDTOs
{
    public class AddUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
