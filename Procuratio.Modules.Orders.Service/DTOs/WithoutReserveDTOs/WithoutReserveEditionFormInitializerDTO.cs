using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;

namespace Procuratio.Modules.Order.Service.DTOs.WithoutReserveDTOs
{
    public class WithoutReserveEditionFormInitializerDTO : IEntityEditionFormInitializerDTO
    {
        public WithoutReserveDTO WithoutReserve { get; set; }

        public MultipleSelectListItemForEditionDTO Tables { get; set; } = new MultipleSelectListItemForEditionDTO();
    }
}
