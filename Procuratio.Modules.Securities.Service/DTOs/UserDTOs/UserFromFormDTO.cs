using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Security.Service.DTOs.UserDTOs
{
    public class UserFromFormDTO : IFromFormDTO
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
