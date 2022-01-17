using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;
using System.Collections.Generic;

namespace Procuratio.Modules.Menu.Service.DTOs.ItemDTOs
{
    public class ItemCreationFormInitializerDTO : IEntityCreationFormInitializerDTO
    {
        public List<SelectListItemDTO> MenuCategories { get; set; } = new List<SelectListItemDTO>();
    }
}
