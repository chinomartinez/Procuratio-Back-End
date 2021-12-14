using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs
{
    public class MenuSubcategoryEditionFormInitializerDTO : IEntityEditionFormInitializerDTO<MenuSubcategoryDTO>
    {
        public MenuSubcategoryDTO BaseProperties { get; set; }
    }
}
