using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Security.Service.DTOs.UserDTOs
{
    public class UserForListDTO : IListDTO<UserDTO>
    {
        public UserDTO BaseProperties { get; set; }
    }
}
