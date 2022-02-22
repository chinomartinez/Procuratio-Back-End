using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;
using Procuratio.Shared.ProcuratioFramework.DTO.SelectListItem;

namespace Procuratio.Modules.Menu.Service.DTOs.ItemDTOs
{
    public class ItemEditionFormInitializerDTO : IEntityEditionFormInitializerDTO<ItemDTO>
    {
        public ItemDTO BaseProperties { get; set; }

        public SingleSelectListItemForEditionDTO MenuCategories { get; set; } = new SingleSelectListItemForEditionDTO();
    }
}
