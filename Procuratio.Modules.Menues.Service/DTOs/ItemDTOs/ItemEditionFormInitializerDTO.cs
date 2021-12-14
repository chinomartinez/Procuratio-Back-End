using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Menu.Service.DTOs.ItemDTOs
{
    public class ItemEditionFormInitializerDTO : IEntityEditionFormInitializerDTO<ItemDTO>
    {
        public ItemDTO BaseProperties { get; set; }
    }
}
