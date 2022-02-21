using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Securities.Service.DTOs.UserDTOs
{
    public class UserDTO : IDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public short UserStateId { get; set; }

        public string ProfilePicture { get; set; }

        public string UserName { get; set; }
    }
}
