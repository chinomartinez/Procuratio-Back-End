using Procuratio.Modules.Menu.Service.DTOs.MenuSubcategoryDTOs;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseInterfacesOperations;

namespace Procuratio.Modules.Menues.Service.Services.Interfaces
{
    public interface IMenuSubcategoryService : IBaseServiceOperations<MenuSubcategoryDTO, MenuSubcategoryForListDTO, MenuSubcategoryFromFormDTO, MenuSubcategoryCreationFormInitializerDTO, MenuSubcategoryEditionFormInitializerDTO, int>
    {
    }
}
