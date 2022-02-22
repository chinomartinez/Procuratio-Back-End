using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Menu.Service.DTOs.ItemDTOs
{
    public class ItemForListDTO : IListDTO<ItemDTO>
    {
        public ItemDTO BaseProperties { get; set; }

        public string CategoryName { get; set; }
    }
}
