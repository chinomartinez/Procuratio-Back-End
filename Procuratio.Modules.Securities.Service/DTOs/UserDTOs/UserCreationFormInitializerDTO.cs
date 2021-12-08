using Procuratio.Modules.Securities.Service.DTOs.UserDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;
using System.Collections.Generic;

namespace Procuratio.Modules.Security.Service.DTOs.UserDTOs
{
    public class UserCreationFormInitializerDTO : IEntityCreationFormInitializerDTO
    {
        public List<SelectListItemDTO> Roles { get; set; } = new List<SelectListItemDTO>();
    }
}
