using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Modules.Security.Service.DTOs.UserDTOs.Profile
{
    public class ProfileEditionFormInitializerDTO : IFromFormDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string ProfilePicture { get; set; }

        public string PhoneNumber { get; set; }

        public IList<string> Roles { get; set; }
    }
}
