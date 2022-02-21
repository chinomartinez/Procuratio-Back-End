using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;

namespace Procuratio.Modules.Security.Service.DTOs.UserDTOs
{
    public class UserEditionFormInitializerDTO : IEntityEditionFormInitializerDTO<UserDTO>
    {
        public UserDTO BaseProperties { get; set; }

        public SingleSelectListItemForEditionDTO Roles { get; set; } = new SingleSelectListItemForEditionDTO();
    }
}
