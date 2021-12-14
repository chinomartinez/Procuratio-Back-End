using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs
{
    public class MenuCategoryForListDTO : IListDTO<MenuCategoryDTO>
    {
        public MenuCategoryDTO BaseProperties { get; set; }
    }
}
