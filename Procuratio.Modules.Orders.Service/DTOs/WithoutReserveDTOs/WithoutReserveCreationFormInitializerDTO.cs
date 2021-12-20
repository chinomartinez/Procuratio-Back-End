using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;
using System.Collections.Generic;

namespace Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs
{
    public class WithoutReserveCreationFormInitializerDTO : IEntityCreationFormInitializerDTO
    {
        public List<SelectListItemDTO> Tables { get; set; } = new List<SelectListItemDTO>();
    }
}
