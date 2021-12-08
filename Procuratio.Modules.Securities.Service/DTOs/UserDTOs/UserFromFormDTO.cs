using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System.ComponentModel.DataAnnotations;

namespace Procuratio.Modules.Security.Service.DTOs.UserDTOs
{
    public class UserFromFormDTO : IFromFormDTO
    {
        public string ProfilePicture { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
