using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Menu.Service.DTOs.MenuCategoryDTOs
{
    public class MenuCategoryEditionFormInitializerDTO : IEntityEditionFormInitializerDTO<MenuCategoryDTO>
    {
        public MenuCategoryDTO BaseProperties { get; set; }
    }
}
