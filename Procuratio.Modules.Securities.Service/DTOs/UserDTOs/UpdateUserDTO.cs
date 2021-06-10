using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Securities.Service.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
