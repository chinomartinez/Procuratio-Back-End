using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations.DTO;

namespace Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs
{
    public class MenuSubcategoryFromFormDTO : IFromFormDTO
    {
        public string Name { get; set; }

        public int? MenuCategoryId { get; set; }
    }
}
